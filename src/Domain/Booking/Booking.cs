using Domain.Booking.Enums;
using Domain.Booking.ValueObjects;
using Domain.Common.Primitives;
using Domain.Common.ValueObjects;
using Domain.RoomType.ValueObjects;
using Domain.User.ValueObjects;

namespace Domain.Booking;

public class Booking : AggregateRoot<BookingId>
{
    public Booking(BookingId bookingId,
                   UserId userId,
                   RoomTypeId roomTypeId,
                   DateTime fromDate,
                   DateTime toDate,
                   int roomCount) : base(bookingId)
    {
        UserId = userId;
        RoomTypeId = roomTypeId;
        FromDate = fromDate;
        EndDate = toDate;
        RoomCount = roomCount;
    }

    public UserId UserId { get; set; }
    public RoomTypeId RoomTypeId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime EndDate { get; set; }
    public int RoomCount { get; set; } = 1;
    public BookingStatus BookingStatus { get; set; } = BookingStatus.Created;

    public static Booking Create(
        UserId userId,
        RoomTypeId roomTypeId,
        DateTime fromDate,
        DateTime toDate,
        int roomCount)
    {
        var booking = new Booking(BookingId.Create(BaseId.NewId), userId, roomTypeId, fromDate, toDate, roomCount);
        return booking;
    }
}
