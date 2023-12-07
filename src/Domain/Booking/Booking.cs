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

    public UserId UserId { get; private set; }
    public RoomTypeId RoomTypeId { get; private set; }
    public DateTime FromDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int RoomCount { get; private set; } = 1;
    public BookingStatus BookingStatus { get; private set; } = BookingStatus.Created;

    public static Booking Create(
        Guid userId,
        Guid roomTypeId,
        DateTime fromDate,
        DateTime toDate,
        int roomCount)
    {
        var booking = new Booking(BookingId.Create(BaseId.NewId), UserId.Create(userId),RoomTypeId.Create(roomTypeId), fromDate, toDate, roomCount);
        return booking;
    }

    public void Update(
        UserId userId,
        RoomTypeId roomTypeId,
        DateTime fromDate,
        DateTime toDate,
        int roomCount)
    {
        this.UserId = userId;
        this.RoomTypeId = roomTypeId;
        this.FromDate = fromDate;
        this.EndDate = toDate;
        this.RoomCount = roomCount;
    }

    public void UpdateStatus(BookingStatus status)
    {
        this.BookingStatus = status;
    }
}
