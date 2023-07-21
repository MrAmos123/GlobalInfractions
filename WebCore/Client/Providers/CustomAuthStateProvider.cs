﻿using System.Security.Claims;
using BanHub.WebCore.Shared.Models.Shared;
using Microsoft.AspNetCore.Components.Authorization;

namespace BanHub.WebCore.Client.Providers;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _claimsPrincipal = new(new ClaimsIdentity());

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return new AuthenticationState(_claimsPrincipal);
    }

    public void SetAuthInfo(WebUser webUserProfile)
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Role, webUserProfile.WebRole),
            new Claim(ClaimTypes.Role, webUserProfile.CommunityRole),
            new Claim(ClaimTypes.Name, webUserProfile.UserName),
            new Claim(ClaimTypes.NameIdentifier, webUserProfile.Identity),
            new("SignedInGuid", webUserProfile.SignedInGuid)
        }, "AuthCookie");

        _claimsPrincipal = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public void ClearAuthInfo()
    {
        _claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
