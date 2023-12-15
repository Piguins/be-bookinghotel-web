namespace Application.Rooms.Commands.CreateRoom;

public record CreateRoomCommand(
    string Name,
    string Description,
    int Floor,
    int BedCount,
    decimal Amount,
    string Currency,
    ICollection<string> Images) : ICommand<RoomResult>;
