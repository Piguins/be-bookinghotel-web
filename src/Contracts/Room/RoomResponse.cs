namespace Contracts.Room;

public record RoomResponse(
    Guid RoomId,
    Guid RoomTypeId,
    bool IsReserved,
    string Name);

