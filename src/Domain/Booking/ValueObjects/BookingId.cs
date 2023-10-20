using Domain.Common.ValueObjects;

namespace Domain.Booking.ValueObjects;

public class BookingId : BaseId
{
    public BookingId(Guid value) : base(value)
    {
    }

    public static new BookingId Create() => new(BaseId.Create());
}
