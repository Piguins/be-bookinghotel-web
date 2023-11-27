using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Booking.ValueObjects;
using Domain.Common.Primitives;
using Domain.Host.ValueObjects;
using Domain.User.ValuedObjects;

namespace Domain.Host;
public class Host : AggregateRoot<HostId>
{
    public Host(HostId id) : base(id)
    {
    }

    public BookingId BookingId { get; set; }
    public UserId Userid { get; set; }
    //public RoomRating RoomRating { get; set; }
}
