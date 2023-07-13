﻿using BanHubData.Commands.Instance.Server;
using RestEase;

namespace BanHub.Interfaces;

public interface IServerService
{
    [Post("/Server")]
    Task<HttpResponseMessage> CreateOrUpdateServerAsync([Query("authToken")] string authToken, [Body] CreateOrUpdateServerCommand server);
}
