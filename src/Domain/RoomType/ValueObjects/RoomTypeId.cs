using Domain.Common.ValueObjects;

namespace Domain.RoomType.ValueObjects;

public class RoomTypeId : BaseId
{
    private RoomTypeId(Guid value) : base(value)
    {
    }

    public static RoomTypeId Create(Guid value) => new(value);
    public static new RoomTypeId NewId => new(BaseId.NewId);
}
