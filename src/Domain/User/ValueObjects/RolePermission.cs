using Domain.Common.Primitives;

namespace Domain.User.ValueObjects;

public sealed class RolePermission : ValueObject
{
    public int RoleId { get; private set; }
    public int PermissionId { get; private set; }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return RoleId;
        yield return PermissionId;
    }

    // #pragma warning disable CS8618
    //     private RolePermission() { }
    // #pragma warning restore CS8618
}
