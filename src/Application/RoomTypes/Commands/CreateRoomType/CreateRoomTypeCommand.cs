namespace Application.RoomTypes.Commands.CreateRoomType;

public record CreateRoomTypeCommand(
    int Floor,
    int BedCount,
    decimal Amount,
    string Currency) : ICommand<RoomTypeCommandResult>;
