using Domain.Booking.Enums;
using Domain.Booking.ValueObjects;
using Domain.Common.Primitives;
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
                   uint roomCount) : base(bookingId)
    {
        UserId = userId;
        RoomTypeId = roomTypeId;
        FromDate = fromDate;
        ToDate = toDate;
        RoomCount = roomCount;
    }

    public UserId UserId { get; set; }
    public RoomTypeId RoomTypeId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public uint RoomCount { get; set; } = 1;
    public BookingStatus BookingStatus { get; set; } = BookingStatus.Created;
}
