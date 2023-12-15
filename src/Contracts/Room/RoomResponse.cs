namespace Contracts.Room;

public record RoomResponse(
    Guid Id,
    string Name,
    string Description,
    bool IsReserved,
    string Floor,
    int BedCount,
    decimal PriceAmount,
    string PriceCurrency,
    ICollection<string> Images);

