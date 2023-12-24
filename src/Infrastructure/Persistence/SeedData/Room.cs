namespace Infrastructure.Persistence.SeedData;

internal class Room
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsReserved { get; set; }
    public string Floor { get; set; } = string.Empty;
    public int BedCount { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;
    public IList<string> Images { get; set; } = new List<string>();
}
