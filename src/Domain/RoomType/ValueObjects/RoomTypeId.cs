using Domain.Common.ValueObjects;

namespace Domain.RoomType.ValueObjects;

public class RoomTypeId : BaseId
{
    public RoomTypeId(Guid value) : base(value)
    {
    }

    public static RoomTypeId Create(Guid value) => new(value);
}
