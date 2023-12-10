namespace Application.Rooms.Commands.UpdateRoom;

public record UpdateRoomCommand(
    Guid RoomId,
    Guid? RoomTypeId,
    string? Name,
    bool? IsReserved) : ICommand<RoomCommandResult>;
