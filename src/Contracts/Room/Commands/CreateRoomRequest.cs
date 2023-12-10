namespace Contracts.Room.Commands;

public record CreateRoomRequest(
    Guid RoomTypeId,
    string Name);
