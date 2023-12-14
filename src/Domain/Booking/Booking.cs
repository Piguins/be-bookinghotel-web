using Domain.Booking.Enums;
using Domain.Booking.ValueObjects;
using Domain.Common.Enums;
using Domain.Common.Primitives;
using Domain.User.ValueObjects;

namespace Domain.Booking;

public class Booking : AggregateRoot<BookingId>
{
    private Booking(BookingId bookingId,
                    UserId guestId,
                    DateTime fromDate,
                    DateTime toDate,
                    Floor floor,
                    int bedCount) : base(bookingId)
    {
        GuestId = guestId;
        FromDate = fromDate;
        ToDate = toDate;
        Floor = floor;
        BedCount = bedCount;
    }

    public UserId GuestId { get; private set; }
    public DateTime FromDate { get; private set; }
    public DateTime ToDate { get; private set; }
    public Floor Floor { get; private set; }
    public int BedCount { get; private set; }
    public BookingStatus BookingStatus { get; private set; } = BookingStatus.Created;

    public static Booking Create(
        Guid userId,
        DateTime fromDate,
        DateTime toDate,
        Floor floor,
        int bedCount)
    {
        var booking = new Booking(
            BookingId.NewId,
            UserId.Create(userId),
            fromDate,
            toDate,
            floor,
            bedCount);
        return booking;
    }

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

    public void UpdateStatus(BookingStatus status) => BookingStatus = status;
}
