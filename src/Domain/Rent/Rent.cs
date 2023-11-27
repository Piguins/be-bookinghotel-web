using Domain.Common.Primitives;
using Domain.Common.ValueObjects;
using Domain.Rent.ValueObjects;
using Domain.Room.ValueObjects;
using Domain.User.ValueObjects;

namespace Domain.Rent;

public sealed class Rent : AggregateRoot<RentId>
{
    public Rent(RentId id,
                RoomId roomId,
                UserId hostId,
                UserId guestId,
                DateTime atDate,
                Money pricePerDay) : base(id)
    {
        RoomId = roomId;
        HostId = hostId;
        GuestId = guestId;
        AtDate = atDate;
        PricePerDay = pricePerDay;
    }

    public RoomId RoomId { get; private set; }
    public UserId HostId { get; private set; }
    public UserId GuestId { get; private set; }
    public DateTime AtDate { get; private set; }
    public Money PricePerDay { get; private set; }

    // #pragma warning disable CS8618
    //     private Rent() { }
    // #pragma warning restore CS8618
}
