using Domain.Common.ValueObjects;

namespace Domain.Booking.ValueObjects;

public class BookingId : BaseId
{
    public BookingId(Guid value) : base(value)
    {
    }
}
