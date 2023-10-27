using Domain.Common.ValueObjects;

namespace Domain.User.ValueObjects;

public class UserId : BaseId
{
    public UserId(Guid value) : base(value)
    {
    }
}
