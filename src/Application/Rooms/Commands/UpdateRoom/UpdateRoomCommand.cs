namespace Application.Rooms.Commands.UpdateRoom;

public record UpdateRoomCommand(
    Guid RoomId,
    string? Name,
    string? Description,
    bool? IsReserved,
    int? Floor,
    int? BedCount,
    decimal? Amount,
    string? Currency,
    ICollection<string>? Images) : ICommand<RoomResult>;
