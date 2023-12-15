namespace Application.Rooms.Commands.DeleteRoom;

public record DeleteRoomCommand(
    Guid RoomId) : ICommand<RoomResult>;
