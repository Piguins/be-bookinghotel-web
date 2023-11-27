using Domain.Common.ValueObjects;

namespace Domain.Guest.ValueObjects;

public class GuestId : BaseId
{
    public GuestId(Guid value) : base(value)
    {
    }
}
