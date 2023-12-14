namespace Application.Rooms.Commands.CreateRoom;

public record CreateRoomCommand(
    string Name,
    int Floor,
    int BedCount,
    decimal Amount,
    string Currency) : ICommand<RoomCommandResult>;
