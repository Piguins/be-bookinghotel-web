namespace Application.Rooms.Commands.UpdateRoom;

public record UpdateRoomCommand(
    Guid RoomId,
    string? Name,
    bool? IsReserved,
    int? Floor,
    int? BedCount,
    decimal? Amount,
    string? Currency) : ICommand<RoomCommandResult>;
