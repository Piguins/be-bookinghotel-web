namespace Contracts.Room.Commands;

public record UpdateRoomRequest(
    Guid RoomId,
    string? Name,
    bool? IsReserved,
    int? Floor,
    int? BedCount,
    decimal? Amount,
    string? Currency);
