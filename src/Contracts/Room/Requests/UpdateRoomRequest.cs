namespace Contracts.Room.Requests;

public record UpdateRoomRequest(
    Guid RoomId,
    string? Name,
    string? Description,
    bool? IsReserved,
    int? Floor,
    int? BedCount,
    decimal? Amount,
    string? Currency,
    ICollection<string>? Images);
