using Domain.Common.Primitives;
using Domain.Common.ValueObjects;
using Domain.Bill.ValueObjects;
using Domain.User.ValueObjects;
using Domain.Rent.ValueObjects;

namespace Domain.Bill;

public sealed class Bill : AggregateRoot<BillId>
{
    private readonly List<RentId> _rentIds = new();

    public Bill(BillId id,
                UserId hostId,
                UserId guestId,
                DateTime atDate) : base(id)
    {
        HostId = hostId;
        GuestId = guestId;
        AtDate = atDate;
    }

    public UserId HostId { get; private set; }
    public UserId GuestId { get; private set; }
    public DateTime AtDate { get; private set; }
    public Money TotalPrice { get; private set; } = Money.VND;
    public IReadOnlyList<RentId> RentIds => _rentIds.AsReadOnly();

    // #pragma warning disable CS8618
    //     private Bill() { }
    // #pragma warning restore CS8618
}
