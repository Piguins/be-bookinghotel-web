using Domain.Common.ValueObjects;

namespace Domain.User.ValueObjects;
public sealed class PersonId : BaseId
{
    public PersonId(Guid value) : base(value)
    {
    }
}
