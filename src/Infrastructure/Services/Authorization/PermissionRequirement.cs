using Microsoft.AspNetCore.Authorization;
using Domain.Users.Enums;

namespace Infrastructure.Services.Authorization;

public class PermissionRequirement : IAuthorizationRequirement
{
    public Role Role { get; private set; }

    private PermissionRequirement(Role role)
    {
        Role = role;
    }

    public static PermissionRequirement Host => new(Role.Host);
    public static PermissionRequirement Guest => new(Role.Guest);
}
