using Domain.Bookings.ValueObjects;
using Domain.Common.Enums;
using Domain.Common.Primitives;
using Domain.Users;

namespace Domain.Bookings;

public class Booking : AggregateRoot<BookingId>
{
    private Booking(BookingId bookingId,
                    User user,
                    OrderId orderId,
                    DateTime fromDate,
                    DateTime toDate,
                    Floor floor,
                    int bedCount
    ) : base(bookingId)
    {
        User = user;
        FromDate = fromDate;
        ToDate = toDate;
        Floor = floor;
        BedCount = bedCount;
        OrderId = orderId;
    }

    public User User { get; private set; }
    public OrderId OrderId { get; private set; }
    public DateTime FromDate { get; private set; }
    public DateTime ToDate { get; private set; }
    public Floor Floor { get; private set; }
    public int BedCount { get; private set; }

    public static Booking Create(
        User user,
        Guid orderId,
        DateTime fromDate,
        DateTime toDate,
        Floor floor,
        int bedCount)
        => new(
            BookingId.NewId,
            user,
            OrderId.Create(orderId),
            fromDate,
            toDate,
            floor,
            bedCount);

    public void Update(
        DateTime? fromDate,
        DateTime? toDate,
        Floor? floor,
        int? bedCount)
    {
        FromDate = fromDate ?? FromDate;
        ToDate = toDate ?? ToDate;
        Floor = floor ?? Floor;
        BedCount = bedCount ?? BedCount;
    }

#pragma warning disable CS8618
    private Booking() { }
#pragma warning restore CS8618
}
