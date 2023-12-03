using Domain.Common.ValueObjects;
using Domain.User.ValueObjects;

namespace Domain.Booking.ValueObjects;

public class BookingId : BaseId
{
    public BookingId(Guid value) : base(value)
    {
    }

    public static BookingId Create(Guid value) => new(value);
    public static new BookingId NewId => new(BaseId.NewId);
}
