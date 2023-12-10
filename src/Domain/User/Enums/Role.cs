using Domain.Common.Primitives;

namespace Domain.User.Enums;

public class Role : Enumeration<Role>
{
    public static readonly Role Guest = new(1, "Host");
    public static readonly Role Host = new(2, "Guest");

    private readonly List<Permission> _permissions = [];
    private readonly List<User> _users = [];

    private Role(int priority, string name) : base(priority, name)
    {
    }

    public IReadOnlyList<Permission> Permissions => _permissions.AsReadOnly();
    public IReadOnlyList<User> Users => _users.AsReadOnly();

    // private sealed class HostRole : Role
    // {
    //     public HostRole() : base(1, "Host")
    //     {
    //     }
    // }
    // private sealed class GuestRole : Role
    // {
    //     public GuestRole() : base(2, "Guest")
    //     {
    //     }
    // }
}
