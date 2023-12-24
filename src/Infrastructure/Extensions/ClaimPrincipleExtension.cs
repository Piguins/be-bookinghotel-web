using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Infrastructure.Extensions;

public static class ClaimPrincipleExtension
{
    public static Guid? GetUserId(this ClaimsPrincipal user)
    {
        string? userId = user.Claims
            .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub)
            ?.Value;
        return (userId is null || !Guid.TryParse(userId, out var guid)) ? null : guid;
    }
}
