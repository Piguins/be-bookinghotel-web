using Domain.Common.Primitives;
using Domain.Common.ValueObjects;
using Domain.User.ValueObjects;
using Domain.Room.ValueObjects;
using Domain.RoomType.Enums;
using Domain.RoomType.ValueObjects;
using Domain.Booking.ValueObjects;

namespace Domain.RoomType;

public sealed class RoomType : AggregateRoot<RoomTypeId>
{
    private readonly List<RoomId> _roomIds = new();

    public RoomType(RoomTypeId roomTypeId,
                    Floor floor,
                    int bedCount,
                    Money price)
        : base(roomTypeId)
    {
        Floor = floor;
        BedCount = bedCount;
        Price = price;
    }

    public Floor Floor { get; private set; }
    public int BedCount { get; private set; }
    public Money Price { get; private set; }
    public IReadOnlyList<RoomId> RoomIds => _roomIds.AsReadOnly();

    public static RoomType Create(
        int floor,
        int bedCount,
        decimal amount,
        int currency)
    {
        return new RoomType(RoomTypeId.Create(BaseId.NewId), Floor.FromValue(floor), bedCount, Money.Create(currency,amount));
    }


    // #pragma warning disable CS8618
    //     private RoomType() { }
    // #pragma warning restore CS8618
}
