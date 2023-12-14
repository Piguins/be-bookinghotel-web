using Domain.Common.Enums;
using Domain.Common.Primitives;
using Domain.Common.ValueObjects;
using Domain.Room.Entities;
using Domain.Room.ValueObjects;

namespace Domain.Room;

public sealed class Room : AggregateRoot<RoomId>
{
    private readonly List<RoomRating> _roomRatings = [];

    private Room(RoomId id,
                string name,
                bool isReserved,
                Floor floor,
                int bedCount,
                Money price) : base(id)
    {
        Name = name;
        IsReserved = isReserved;
        Floor = floor;
        BedCount = bedCount;
        Price = price;
    }

    public string Name { get; private set; }
    public bool IsReserved { get; private set; }
    public Floor Floor { get; private set; }
    public int BedCount { get; private set; }
    public Money Price { get; private set; }
    public IReadOnlyList<RoomRating> RoomRatings => _roomRatings.ToList();

    public static Room Create(
        string name,
        bool isReserved,
        Floor floor,
        int bedCount,
        Money price) => new(RoomId.NewId,
                            name,
                            isReserved,
                            floor,
                            bedCount,
                            price);

    public void Update(
        string? name,
        bool? isReserved,
        Floor? floor,
        int? bedCount,
        decimal? amount,
        string? currency)
    {
        Name = name ?? Name;
        IsReserved = isReserved ?? IsReserved;
        Floor = floor ?? Floor;
        BedCount = bedCount ?? BedCount;
        if (currency is not null)
        {
            Price = Money.FromCurrency(currency).Add(Price.Amount);
        }
        if (amount is not null)
        {
            Price = Money.FromCurrency(Price.Currency).Add(amount.Value);
        }
    }

    // #pragma warning disable CS8618
    //     private Room() { }
    // #pragma warning restore CS8618
}
