﻿using GlobalInfraction.WebCore.Server.Context;
using GlobalInfraction.WebCore.Server.Enums;
using GlobalInfraction.WebCore.Server.Interfaces;
using GlobalInfraction.WebCore.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalInfraction.WebCore.Server.Services;

public class HeartBeatService : IHeartBeatService
{
    private readonly DataContext _context;

    public HeartBeatService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<(ControllerEnums.ProfileReturnState, bool)> InstanceHeartbeat(InstanceDto request)
    {
        var instance = await _context.Instances
            .AsTracking()
            .FirstOrDefaultAsync(x => x.InstanceGuid == request.InstanceGuid && x.ApiKey == request.ApiKey);
        if (instance is null) return (ControllerEnums.ProfileReturnState.NotFound, false);

        instance.HeartBeat = DateTimeOffset.UtcNow;
        _context.Instances.Update(instance);
        await _context.SaveChangesAsync();
        return (ControllerEnums.ProfileReturnState.Updated, instance.Active);
    }

    public async Task EntitiesHeartbeat(List<EntityDto> request)
    {
        var profiles = await _context.Entities
            .AsTracking()
            .Where(p => request
                .Select(r => r.Identity)
                .Contains(p.Identity))
            .ToListAsync();

        foreach (var profile in profiles)
        {
            profile.HeartBeat = DateTimeOffset.UtcNow;
            _context.Entities.Update(profile);
        }

        await _context.SaveChangesAsync();
    }
}
