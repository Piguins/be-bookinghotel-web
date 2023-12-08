using Domain.Common.Primitives;

namespace Domain.User.Enums;

public abstract class Role : Enumeration<Role>
{
    public static readonly Role Guest = new GuestRole();
    public static readonly Role Host = new HostRole();

    private readonly List<Permission> _permissions = [];
    private readonly List<User> _users = [];

    private Role(int value, string name) : base(value, name)
    {
    }

    public IReadOnlyList<Permission> Permissions => _permissions.AsReadOnly();
    public IReadOnlyList<User> Users => _users.AsReadOnly();

    private sealed class GuestRole : Role
    {
        public GuestRole() : base(1, "Guest")
        {
        }
    }
    private sealed class HostRole : Role
    {
        public HostRole() : base(2, "Host")
        {
        }
    }
}
