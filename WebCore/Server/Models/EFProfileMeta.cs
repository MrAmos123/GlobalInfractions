﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalInfraction.WebCore.Server.Models;

public class EFProfileMeta
{
    [Key] public int Id { get; set; }

    /// <summary>
    /// The player's name
    /// </summary>
    public string UserName { get; set; } = null!;

    /// <summary>
    /// The player's IP address
    /// </summary>
    public string IpAddress { get; set; } = null!;

    /// <summary>
    /// The last time the player's name changed
    /// </summary>
    public DateTimeOffset Changed { get; set; }

    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))] public EFProfile Profile { get; set; } = null!;
}
