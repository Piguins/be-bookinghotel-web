namespace Application.RoomTypes.Commands.DeleteRoomType;

public record DeleteRoomTypeCommand(
    Guid RoomTypeId) : ICommand<RoomTypeCommandResult>;

