namespace Contracts.Room.Commands;

public record CreateRoomRequest(
    string Name,
    int Floor,
    int BedCount,
    decimal Amount,
    string Currency);
