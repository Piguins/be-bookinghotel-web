using Domain.User.Enums;

namespace Infrastructure.Services.Authorization;

public abstract class Permission
{
    protected Permission(List<Role> roles)
    {
        Roles = roles;
    }

    public List<Role> Roles { get; }

    public sealed class HostPermission : Permission
    {
        public HostPermission() : base([Role.Host]) { }
    }

    public sealed class GuestPermission : Permission
    {
        public GuestPermission() : base([Role.Guest]) { }
    }
}

