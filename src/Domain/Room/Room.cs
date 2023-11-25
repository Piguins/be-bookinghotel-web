using Domain.Common.Primitives;
using Domain.Room.Entities;
using Domain.Room.ValueObjects;
using Domain.RoomType.ValueObjects;

namespace Domain.Room;

public sealed class Room : AggregateRoot<RoomId>
{
    private readonly List<RoomRating> _roomRatings = new();

    public Room(RoomId id,
                string name,
                bool isReserved,
                RoomTypeId roomTypeId) : base(id)
    {
        Name = name;
        IsReserved = isReserved;
        RoomTypeId = roomTypeId;
    }

    public string Name { get; private set; }
    public bool IsReserved { get; private set; }
    public RoomTypeId RoomTypeId { get; private set; }
    public IReadOnlyList<RoomRating> RoomRatings => _roomRatings.ToList();

    // #pragma warning disable CS8618
    //     private Room() { }
    // #pragma warning restore CS8618
}