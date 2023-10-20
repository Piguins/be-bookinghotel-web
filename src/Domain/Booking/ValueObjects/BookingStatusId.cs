using Domain.Common.ValueObjects;

namespace Domain.Booking.ValueObjects;

public class BookingStatusId : BaseId
{
    public BookingStatusId(Guid value) : base(value)
    {
    }

    public static new BookingStatusId Create() => new(BaseId.Create());
}
