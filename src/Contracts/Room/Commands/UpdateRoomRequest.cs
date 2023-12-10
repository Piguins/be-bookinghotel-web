namespace Contracts.Room.Commands;

public record UpdateRoomRequest(
    Guid RoomId,
    Guid? RoomTypeId,
    bool? IsReserved,
    string? Name);
