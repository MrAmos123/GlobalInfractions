﻿namespace GlobalInfraction.WebCore.Shared.Models;

public class EntityDto
{
    /// <summary>
    /// The player's identity
    /// </summary>
    public string Identity { get; set; } = null!;

    /// <summary>
    /// The player's reputation
    /// </summary>
    public int? Reputation { get; set; }

    /// <summary>
    /// The last time the player was seen
    /// </summary>
    public DateTimeOffset? HeartBeat { get; set; }
    
    /// <summary>
    /// The first time we saw the player
    /// </summary>
    public DateTimeOffset? Created { get; set; }

    /// <summary>
    /// The player's meta
    /// </summary>
    public virtual AliasDto? Alias { get; set; }

    /// <summary>
    /// The associated instance
    /// </summary>
    public virtual InstanceDto? Instance { get; set; }

    /// <summary>
    /// The player's list of infractions
    /// </summary>
    public virtual ICollection<InfractionDto>? Infractions { get; set; }
    
    /// <summary>
    /// Servers the client has connected to
    /// </summary>
    public virtual ICollection<ServerDto>? Servers { get; set; }
    
    /// <summary>
    /// Server the client is connected to
    /// </summary>
    public virtual ServerDto? Server { get; set; }
}
