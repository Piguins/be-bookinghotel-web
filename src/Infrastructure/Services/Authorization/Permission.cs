using Domain.Users.Enums;

namespace Infrastructure.Services.Authorization;

public abstract class Permission(List<Role> roles)
{
    public List<Role> Roles { get; } = roles;

    public sealed class HostPermission : Permission
    {
        public HostPermission() : base([Role.Host, Role.Guest]) { }
    }

    public sealed class GuestPermission : Permission
    {
        public GuestPermission() : base([Role.Guest]) { }
    }
}

