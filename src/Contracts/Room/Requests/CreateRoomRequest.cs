namespace Contracts.Room.Requests;

public record CreateRoomRequest(
    string Name,
    string Description,
    int Floor,
    int BedCount,
    decimal Amount,
    string Currency,
    ICollection<string> Images);
