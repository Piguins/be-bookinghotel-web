using Domain.Common.ValueObjects;

namespace Domain.Rent.ValueObjects;

public class RentId : BaseId
{
    public RentId(Guid value) : base(value)
    {
    }
}
