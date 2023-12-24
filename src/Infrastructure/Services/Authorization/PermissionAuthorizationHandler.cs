using Application.Users;
using Domain.Users.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Infrastructure.Extensions;

namespace Infrastructure.Services.Authorization;

public class PermissionAuthorizationHandler(IServiceScopeFactory serviceScopeFactory) : AuthorizationHandler<PermissionRequirement>
{
    protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        if (context.User.GetUserId() is not { } userId)
        {
            return;
        }

        using var scope = serviceScopeFactory.CreateScope();
        var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<PermissionAuthorizationHandler>>();

        if (await userRepository.GetByIdAsync(UserId.Create(userId)) is not { } user)
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
