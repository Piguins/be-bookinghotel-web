using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Booking.ValueObjects;
using Domain.Common.Primitives;
using Domain.Guest.ValueObjects;
using Domain.User.ValuedObjects;

namespace Domain.Guest;
public class Guest : AggregateRoot<GuestId>
{
    public Guest(GuestId id) : base(id)
    {
    }

    public BookingId BookingId { get; set; }
    public UserId UserId { get; set; }
    //public RoomRating RoomRating { get; set; }
}
