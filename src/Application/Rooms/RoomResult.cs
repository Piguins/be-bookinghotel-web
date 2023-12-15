namespace Application.Rooms;

public record RoomResult(
    Guid Id,
    string Name,
    string Description,
    bool IsReserved,
    string Floor,
    int BedCount,
    decimal PriceAmount,
    string PriceCurrency,
    ICollection<string> Images)
{
    // public RoomResult()
    //     : this(Guid.Empty,
    //            string.Empty,
    //            string.Empty,
    //            false,
    //            string.Empty,
    //            0,
    //            0,
    //            string.Empty,
    //            new List<string>())
    // { }
}
