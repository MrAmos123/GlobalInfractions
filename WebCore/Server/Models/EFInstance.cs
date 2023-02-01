﻿using System.ComponentModel.DataAnnotations;

namespace BanHub.WebCore.Server.Models;

/// <summary>
/// Table for the all instances
/// </summary>
public class EFInstance
{
    [Key] public int Id { get; set; }

    /// <summary>
    /// The IW4MAdmin GUID
    /// </summary>
    public required Guid InstanceGuid { get; set; }

    /// <summary>
    /// The IW4MAdmin IP address
    /// </summary>
    public required string InstanceIp { get; set; } = null!;

    /// <summary>
    /// The IW4MAdmin name
    /// </summary>
    public required string? InstanceName { get; set; }

    /// <summary>
    /// The last the the instance has replied
    /// </summary>
    public required DateTimeOffset HeartBeat { get; set; }

    /// <summary>
    /// The IW4MAdmin provided API Key
    /// </summary>
    public required Guid ApiKey { get; set; }

    /// <summary>
    /// State whether the server can upload bans
    /// </summary>
    public required bool Active { get; set; }

    /// <summary>
    /// The list of connected servers
    /// </summary>
    public ICollection<EFServer> ServerConnections { get; set; } = null!;
}
