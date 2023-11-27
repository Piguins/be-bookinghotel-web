using Domain.Common.ValueObjects;

namespace Domain.User.ValueObjects;

public class UserId : BaseId
{
    public UserId(Guid value) : base(value)
    {
    }

    public static UserId Create(Guid value) => new(value);
    public static new UserId NewId => new(BaseId.NewId);
}
