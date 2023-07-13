﻿using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using BanHub.Configuration;
using BanHub.Models;
using BanHub.Services;
using BanHubData.Commands.Instance;
using BanHubData.Commands.Instance.Server;
using BanHubData.Commands.Penalty;
using BanHubData.Commands.Player;
using BanHubData.Enums;
using Microsoft.Extensions.Logging;
using SharedLibraryCore.Database.Models;

namespace BanHub.Managers;

public class EndpointManager
{
    public readonly ConcurrentDictionary<EFClient, string> Profiles = new();
    private readonly ILogger<EndpointManager> _logger;
    private readonly PlayerService _player;
    private readonly BanHubConfiguration _banHubConfiguration;
    private readonly InstanceSlim _instanceSlim;
    private readonly InstanceService _instance;
    private readonly PenaltyService _penalty;
    private readonly ServerService _server;

    public EndpointManager(BanHubConfiguration banHubConfiguration, InstanceSlim instanceSlim,
        PlayerService playerService, InstanceService instanceService, PenaltyService penaltyService,
        ServerService serverService,
        ILogger<EndpointManager> logger)
    {
        _banHubConfiguration = banHubConfiguration;
        _instanceSlim = instanceSlim;
        _player = playerService;
        _instance = instanceService;
        _penalty = penaltyService;
        _server = serverService;
        _logger = logger;
    }

    public async Task<bool> UpdateInstance(CreateOrUpdateInstanceCommand instance) => await _instance.PostInstance(instance);

    public async Task<bool> IsInstanceActive(Guid guid) => await _instance.IsInstanceActive(guid.ToString());

    private string EntityToPlayerIdentity(EFClient client)
    {
        var identity = $"{client.GuidString}:{client.GameName.ToString()}";
        return identity;
    }

    public async Task OnStart(CreateOrUpdateServerCommand server)
    {
        if (!Plugin.InstanceActive) return;
        await _server.PostServer(server);
    }

    public async Task OnJoin(EFClient player)
    {
        // We don't want to act on anything if they're not authenticated
        if (!_instanceSlim.Active) return;

        var createOrUpdate = new CreateOrUpdatePlayerCommand
        {
            PlayerIdentity = $"{player.GuidString}:{player.GameName.ToString()}",
            PlayerAliasUserName = player.CleanedName,
            PlayerAliasIpAddress = player.IPAddressString,
            PlayerInstanceRole = player.ClientPermission.Level switch
            {
                Data.Models.Client.EFClient.Permission.Trusted => InstanceRole.InstanceTrusted,
                Data.Models.Client.EFClient.Permission.Moderator => InstanceRole.InstanceModerator,
                Data.Models.Client.EFClient.Permission.Administrator => InstanceRole.InstanceAdministrator,
                Data.Models.Client.EFClient.Permission.SeniorAdmin => InstanceRole.InstanceSeniorAdmin,
                Data.Models.Client.EFClient.Permission.Owner => InstanceRole.InstanceOwner,
                _ => InstanceRole.InstanceUser
            },
            InstanceGuid = _instanceSlim.InstanceGuid,
            ServerId = player.CurrentServer.Id
        };

        if (await _player.UpdateEntityAsync(createOrUpdate) is not { } identity)
        {
            _logger.LogError("Failed to update entity {Identity}", createOrUpdate.PlayerIdentity);
            return;
        }

        var isBanned = await _player.IsPlayerBannedAsync(new IsPlayerBannedCommand
        {
            Identity = identity,
            IpAddress = player.IPAddressString
        });

        if (isBanned)
        {
            ProcessEntity(player);
            return;
        }

        Profiles.TryAdd(player, identity);
    }

    private void ProcessEntity(EFClient client)
    {
        client.Kick("^1Globally banned!^7\nBanHub.gg",
            SharedLibraryCore.Utilities.IW4MAdminClient(client.CurrentServer));
        _logger.LogInformation("{Name} globally banned", client.CleanedName);
    }

    public void RemoveFromProfiles(EFClient client)
    {
        var canRemoveClient = Profiles.TryRemove(client, out _);
        if (canRemoveClient)
        {
            _logger.LogInformation("Removed {Name} from profiles", client.CleanedName);
            return;
        }

        _logger.LogError("Failed to remove {Name} from profiles", client.CleanedName);
    }

    public async Task<(bool, Guid?)> NewPenalty(string sourcePenaltyType, EFClient origin, EFClient target,
        string reason, TimeSpan? duration = null, PenaltyScope? scope = null, string? evidence = null)
    {
        var parsedPenaltyType = Enum.TryParse<PenaltyType>(sourcePenaltyType, out var penaltyType);
        if (!parsedPenaltyType || !Plugin.InstanceActive) return (false, null);
        if (penaltyType is not PenaltyType.Ban && origin.ClientId is 1) return (false, null);

        var globalAntiCheatBan = false;
        var antiCheatReason = origin.AdministeredPenalties?.FirstOrDefault()?.AutomatedOffense;
        if (antiCheatReason is not null)
        {
            const string regex = @"^(Recoil|Button)(-{1,2})(\d{0,})@(\d{0,})$";
            globalAntiCheatBan = Regex.IsMatch(antiCheatReason, regex);
        }

        var adminIdentity = EntityToPlayerIdentity(origin);
        var targetIdentity = EntityToPlayerIdentity(target);

        var penaltyDto = new AddPlayerPenaltyCommand
        {
            PenaltyType = penaltyType,
            PenaltyScope = globalAntiCheatBan ? PenaltyScope.Global : scope ?? PenaltyScope.Local,
            Reason = globalAntiCheatBan ? "AntiCheat Detection" : reason,
            Automated = globalAntiCheatBan,
            Duration = duration is not null && duration.Value.TotalSeconds > 1 ? duration : null,
            InstanceGuid = _instanceSlim.InstanceGuid,
            AdminIdentity = adminIdentity,
            TargetIdentity = targetIdentity
        };
        var result = await _penalty.PostPenalty(penaltyDto);

        if (_banHubConfiguration.PrintPenaltyToConsole)
        {
            var guid = result.Item1 ? $"GUID: {result.Item2.ToString()}" : "Error creating penalty!";
            Console.WriteLine(
                $"[{BanHubConfiguration.Name} - {DateTimeOffset.UtcNow:HH:mm:ss}] {penaltyType} ({penaltyDto.PenaltyScope}): " +
                $"{origin.CleanedName} -> {target.CleanedName} ({penaltyDto.Reason}) - {guid}");
        }

        return result;
    }

    public async Task<bool> SubmitInformation(Guid guid, string evidence)
    {
        var penalty = new AddPlayerPenaltyEvidenceCommand
        {
            PenaltyGuid = guid,
            Evidence = evidence
        };
        return await _penalty.SubmitEvidence(penalty);
    }

    public async Task<string?> GenerateToken(EFClient client)
    {
        var identity = EntityToPlayerIdentity(client);
        return await _player.GetTokenAsync(new GetPlayerTokenCommand {Identity = identity});
    }
}
