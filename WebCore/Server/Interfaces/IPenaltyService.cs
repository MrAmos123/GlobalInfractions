﻿using BanHub.WebCore.Server.Enums;
using BanHub.WebCore.Shared.DTOs;

namespace BanHub.WebCore.Server.Interfaces;

public interface IPenaltyService
{
    Task<(ControllerEnums.ProfileReturnState, Guid?)> AddPenalty(PenaltyDto request);
    Task<(ControllerEnums.ProfileReturnState, PenaltyDto?)> GetPenalty(string penaltyGuid);
    Task<(ControllerEnums.ProfileReturnState, List<PenaltyDto>?)> GetPenalties();
    Task<bool> SubmitEvidence(PenaltyDto request);
    Task<List<PenaltyDto>> Pagination(PaginationDto pagination);
    Task<List<PenaltyDto>> GetLatestThreeBans();
}
