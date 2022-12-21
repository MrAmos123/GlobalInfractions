﻿namespace GlobalInfraction.WebCore.Shared.Models;

public class ProfileDto
{
    /// <summary>
    /// The player's identity
    /// </summary>
    public string ProfileIdentity { get; init; } = null!;

    /// <summary>
    /// The player's reputation
    /// </summary>
    public int? Reputation { get; init; }

    /// <summary>
    /// The last time the player was seen
    /// </summary>
    public DateTimeOffset Heartbeat { get; set; }

    /// <summary>
    /// The player's meta
    /// </summary>
    public virtual ProfileMetaDto ProfileMeta { get; set; } = null!;

    /// <summary>
    /// The sending server
    /// </summary>
    public virtual InstanceDto? Instance { get; set; }

    /// <summary>
    /// The player's list of infractions
    /// </summary>
    public virtual ICollection<InfractionDto>? Infractions { get; set; }
}
