using Microsoft.AspNetCore.Authorization;
using Domain.User.Enums;

namespace Infrastructure.Services.Authorization;

public class PermissionRequirement : IAuthorizationRequirement
{
    public readonly Role Role;

    private PermissionRequirement(Role role)
    {
        Role = role;
    }

    public static PermissionRequirement Host => new(Role.Host);
    public static PermissionRequirement Guest => new(Role.Guest);
}
