using Domain.Common.ValueObjects;

namespace Domain.Bookings.ValueObjects;

public class BookingId : BaseId
{
    private BookingId(Guid value) : base(value)
    {
    }

    public static BookingId Create(Guid value) => new(value);
    public static new BookingId NewId => new(BaseId.NewId);
}
