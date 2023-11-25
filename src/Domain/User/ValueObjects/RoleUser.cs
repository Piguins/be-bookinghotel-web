using Domain.Common.Primitives;

namespace Domain.User.ValueObjects;

public sealed class RoleUser : ValueObject
{
    public int RoleId { get; private set; }
    public UserId UserId { get; private set; } = null!;

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return RoleId;
        yield return UserId;
    }

    // #pragma warning disable CS8618
    //     private RoleUser() { }
    // #pragma warning restore CS8618
}

