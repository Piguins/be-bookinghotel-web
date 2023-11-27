using Domain.Common.ValueObjects;

namespace Domain.Room.ValueObjects;

public class RoomRatingId : BaseId
{
    public RoomRatingId(Guid value) : base(value)
    {
    }

    public static RoomRatingId Create(Guid value) => new(value);
}
