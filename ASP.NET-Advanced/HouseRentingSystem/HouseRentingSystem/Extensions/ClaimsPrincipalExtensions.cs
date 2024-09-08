﻿namespace System.Security.Claims;

using static HouseRentingSystem.Common.Constants;

public static class ClaimsPrincipalExtensions
{
    public static string? Id(this ClaimsPrincipal user) => user.FindFirstValue(ClaimTypes.NameIdentifier);

    public static bool IsAdmin(this ClaimsPrincipal user) => user.IsInRole(AdminRole);
}