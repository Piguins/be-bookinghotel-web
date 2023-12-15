namespace Contracts.Room.Commands;

public record CreateRoomRequest(
    string Name,
    string Description,
    int Floor,
    int BedCount,
    decimal Amount,
    string Currency,
    ICollection<string> Images);
