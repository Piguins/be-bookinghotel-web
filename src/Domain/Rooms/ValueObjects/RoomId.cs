using Domain.Common.ValueObjects;

namespace Domain.Rooms.ValueObjects;

public class RoomId : BaseId
{
    private RoomId(Guid value) : base(value)
    {
    }

    public static RoomId Create(Guid value) => new(value);
    public static new RoomId NewId => new(BaseId.NewId);
}
