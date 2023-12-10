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

    private RoomType(RoomTypeId roomTypeId,
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
        Floor floor,
        int bedCount,
        Money price)
    {
        return new RoomType(RoomTypeId.NewId, floor, bedCount, price);
    }


    // #pragma warning disable CS8618
    //     private RoomType() { }
    // #pragma warning restore CS8618
}
