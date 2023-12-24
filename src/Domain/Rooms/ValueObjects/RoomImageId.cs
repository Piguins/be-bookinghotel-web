using Domain.Common.ValueObjects;

namespace Domain.Rooms.ValueObjects;

public class RoomImageId : BaseId
{
    private RoomImageId(Guid value) : base(value)
    {
    }

    public static RoomImageId Create(Guid value) => new(value);
    public static new RoomImageId NewId => new(BaseId.NewId);
}
