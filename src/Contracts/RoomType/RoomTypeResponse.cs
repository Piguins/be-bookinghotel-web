namespace Contracts.RoomType;

public record RoomTypeResponse(
    Guid RoomTypeId,
    string Floor,
    int BedCount,
    decimal Amount,
    string Currency);
