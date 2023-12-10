namespace Application.Rooms.Commands.CreateRoom;

public record CreateRoomCommand(
    Guid RoomTypeId,
    string Name) : ICommand<RoomCommandResult>;
