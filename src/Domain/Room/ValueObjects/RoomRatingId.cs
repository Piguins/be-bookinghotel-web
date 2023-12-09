using Domain.Common.ValueObjects;

namespace Domain.Room.ValueObjects;

public class RoomRatingId : BaseId
{
    private RoomRatingId(Guid value) : base(value)
    {
    }

    public static RoomRatingId Create(Guid value) => new(value);
    public static new RoomRatingId NewId => new(BaseId.NewId);
}
