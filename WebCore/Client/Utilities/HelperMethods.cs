﻿using System.Text;
using BanHubData.Enums;

namespace BanHub.WebCore.Client.Utilities;

public static class HelperMethods
{
    public static string GetRolesAsString(IEnumerable<WebRole>? webRoles = null, IEnumerable<CommunityRole>? communityRoles = null)
    {
        var webRoleFormatted = (webRoles ?? Enumerable.Empty<WebRole>())
            .Select(role => $"Web_{role}");

        var communityRoleFormatted = (communityRoles ?? Enumerable.Empty<CommunityRole>())
            .Select(role => $"Community_{role}");

        return string.Join(", ", webRoleFormatted.Concat(communityRoleFormatted));
    }
}
