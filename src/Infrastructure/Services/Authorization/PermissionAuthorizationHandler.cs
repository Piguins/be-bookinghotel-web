using Application.Users;
using Domain.User;
using Domain.User.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace Infrastructure.Services.Authorization;

public class PermissionAuthorizationHandler(IServiceScopeFactory serviceScopeFactory) : AuthorizationHandler<PermissionRequirement>
{
    protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        string? userId = context.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub)?.Value;
        if (userId is null || !Guid.TryParse(userId, out var guid))
        {
            return;
        }

        using var scope = serviceScopeFactory.CreateScope();
        var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<PermissionAuthorizationHandler>>();

        if (await userRepository.GetByIdAsync(UserId.Create(guid)) is not { } user)
        {
            logger.LogWarning("User with Id {UserId} was not found while trying to access an API with {Role} role.", userId, requirement.Role);
            return;
        }

        if (user.Roles.Any(r => r.Equals(requirement.Role)))
        {
            context.Succeed(requirement);
        }
        else
        {
            logger.LogWarning("User with Id {UserId} does not have a {Role} role.", userId, requirement.Role);
        }
    }
}
