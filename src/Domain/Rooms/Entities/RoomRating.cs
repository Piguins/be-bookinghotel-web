using Domain.Common.Primitives;
using Domain.Rooms.Enums;
using Domain.Rooms.ValueObjects;
using Domain.Users.ValueObjects;

namespace Domain.Rooms.Entities;

public sealed class RoomRating(
    RoomRatingId roomRatingId,
    RoomId roomId,
    UserId userId,
    RateType rateType,
    DateTime atDate
) : Entity<RoomRatingId>(roomRatingId)
{
    public RoomId RoomId { get; private set; } = roomId;
    public UserId UserId { get; private set; } = userId;
    public RateType RateType { get; private set; } = rateType;
    public DateTime AtDate { get; private set; } = atDate;

    // #pragma warning disable CS8618
    //     private RoomRating() { }
    // #pragma warning restore CS8618
}
