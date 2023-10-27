using Domain.Booking.ValueObjects;
using Domain.Common.Primitives;
using Domain.Host.ValueObjects;
using Domain.User.ValueObjects;

namespace Domain.Host;
public class Host : AggregateRoot<HostId>
{
    public Host(HostId id, BookingId bookingId, UserId userid) : base(id)
    {
        BookingId = bookingId;
        Userid = userid;
    }

    public BookingId BookingId { get; set; }
    public UserId Userid { get; set; }
    //public RoomRating RoomRating { get; set; }
}
