using Domain.Common.ValueObjects;

namespace Domain.Room.ValueObjects;

public class RoomId : BaseId
{
    public RoomId(Guid value) : base(value)
    {
    }

    public static new RoomId Create() => new(BaseId.Create());
}
