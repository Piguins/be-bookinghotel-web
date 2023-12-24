using Domain.Common.ValueObjects;

namespace Domain.Bookings.ValueObjects;

public class OrderId : BaseId
{
    private OrderId(Guid value) : base(value)
    {
    }

    public static OrderId Create(Guid value) => new(value);
    public static new OrderId NewId => new(BaseId.NewId);
}
