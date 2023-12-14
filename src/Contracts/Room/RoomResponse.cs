namespace Contracts.Room;

public record RoomResponse(
    Guid RoomId,
    string Name,
    bool IsReserved,
    string Floor,
    int BedCount,
    decimal Amount,
    string Currency);

