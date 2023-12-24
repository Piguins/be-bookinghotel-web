using Domain.Common.Primitives;

namespace Domain.Users.Enums;

public class Role : Enumeration<Role>
{
    public static readonly Role Host = new(1, nameof(Host));
    public static readonly Role Guest = new(2, nameof(Guest));

    private Role(int priority, string name) : base(priority, name)
    {
    }

#pragma warning disable CS8618
    private Role() { }
#pragma warning restore CS8618
}
