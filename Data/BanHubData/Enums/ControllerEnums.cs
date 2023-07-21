﻿namespace BanHubData.Enums;

public abstract class ControllerEnums
{
    public enum ReturnState
    {
        Updated,
        Created,
        NotFound,
        BadRequest,
        Conflict,
        Accepted,
        Ok,
        Unauthorized,
        NoContent
    }

    public enum StatisticType
    {
        EntityCount = -4,
        ServerCount = -3,
        PenaltyCount = -2,
        CommunityCount = -1
    }

    public enum StatisticTypeAction
    {
        Add,
        Remove
    }
}
