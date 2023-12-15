using Domain.Common.Enums;
using Domain.Common.Primitives;
using Domain.Common.ValueObjects;
using Domain.Room.Entities;
using Domain.Room.ValueObjects;

namespace Domain.Room;

public sealed class Room : AggregateRoot<RoomId>
{
    private readonly List<RoomRating> _roomRatings = [];
    private readonly List<string> _images = [];

    private Room(RoomId id,
                string name,
                string description,
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
        Description = description;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsReserved { get; private set; }
    public Floor Floor { get; private set; }
    public int BedCount { get; private set; }
    public Money Price { get; private set; }

    public IReadOnlyList<string> Images => _images.ToList();
    public IReadOnlyList<RoomRating> RoomRatings => _roomRatings.ToList();

    public static Room Create(
        string name,
        string description,
        bool isReserved,
        Floor floor,
        int bedCount,
        Money price,
        ICollection<string> images)
    {
        var room = new Room(RoomId.NewId,
                            name,
                            description,
                            isReserved,
                            floor,
                            bedCount,
                            price);
        room._images.AddRange(images);

        return room;
    }

    public void Update(
        string? name,
        string? description,
        bool? isReserved,
        Floor? floor,
        int? bedCount,
        decimal? amount,
        string? currency,
        ICollection<string>? images)
    {
        Name = name ?? Name;
        Description = description ?? Description;
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
        if (images is not null)
        {
            _images.Clear();
            _images.AddRange(images);
        }
    }

    // #pragma warning disable CS8618
    //     private Room() { }
    // #pragma warning restore CS8618
}
