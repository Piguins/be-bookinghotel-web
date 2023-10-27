using Domain.Booking.ValueObjects;
using Domain.Common.Primitives;
using Domain.Guest.ValueObjects;
using Domain.User.ValueObjects;

namespace Domain.Guest;
public class Guest : AggregateRoot<GuestId>
{
    public Guest(GuestId id, BookingId bookingId, UserId userId) : base(id)
    {
        BookingId = bookingId;
        UserId = userId;
    }

    public BookingId BookingId { get; set; }
    public UserId UserId { get; set; }
    //public RoomRating RoomRating { get; set; }
}
