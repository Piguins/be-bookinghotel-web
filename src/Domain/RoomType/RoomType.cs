using Domain.Common.Primitives;
using Domain.Common.ValueObjects;
using Domain.User.ValueObjects;
using Domain.Room.ValueObjects;
using Domain.RoomType.Enums;
using Domain.RoomType.ValueObjects;

namespace Domain.RoomType;

public sealed class RoomType : AggregateRoot<RoomTypeId>
{
    private readonly List<RoomId> _roomIds = new();

    public RoomType(RoomTypeId roomTypeId,
                    Floor floor,
                    uint bedCount,
                    Money price,
                    UserId userId)
        : base(roomTypeId)
    {
        Floor = floor;
        BedCount = bedCount;
        Price = price;
        UserId = userId;
    }

    public Floor Floor { get; private set; }
    public uint BedCount { get; private set; }
    public Money Price { get; private set; }
    public UserId UserId { get; private set; }

    public IReadOnlyList<RoomId> RoomIds => _roomIds.AsReadOnly();

    // #pragma warning disable CS8618
    //     private RoomType() { }
    // #pragma warning restore CS8618
}
