using Domain.Common.ValueObjects;

namespace Domain.User.ValuedObjects;

public class UserId : BaseId
{
    public UserId(Guid value) : base(value)
    {
    }
}
