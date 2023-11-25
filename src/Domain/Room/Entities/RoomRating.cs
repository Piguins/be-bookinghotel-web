using Domain.Common.Primitives;
using Domain.User.ValueObjects;
using Domain.Room.ValueObjects;
using Domain.Room.Enums;

namespace Domain.Room.Entities;

public sealed class RoomRating : Entity<RoomRatingId>
{
    public RoomRating(RoomRatingId roomRatingId,
                      RoomId roomId,
                      UserId userId,
                      RateType rateType,
                      DateTime atDate) : base(roomRatingId)
    {
        RoomId = roomId;
        UserId = userId;
        RateType = rateType;
        AtDate = atDate;
    }

    public RoomId RoomId { get; private set; }
    public UserId UserId { get; private set; }
    public RateType RateType { get; private set; }
    public DateTime AtDate { get; private set; }

    // #pragma warning disable CS8618
    //     private RoomRating() { }
    // #pragma warning restore CS8618
}
