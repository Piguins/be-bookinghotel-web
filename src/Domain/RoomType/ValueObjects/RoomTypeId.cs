using Domain.Common.ValueObjects;

namespace Domain.RoomType.ValueObjects;

public class RoomTypeId : BaseId
{
    public RoomTypeId(Guid value) : base(value)
    {
    }

    public static new RoomTypeId Create() => new(BaseId.Create());
}
