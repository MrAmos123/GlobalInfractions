﻿namespace BanHub.WebCore.Server.Services;

public class StatisticsTracking
{
    public int Infractions;
    public int Servers;
    public int Instances;
    public int Entities;
    public DateTimeOffset LastSave { get; set; }
    public bool Loaded { get; set; }
}
