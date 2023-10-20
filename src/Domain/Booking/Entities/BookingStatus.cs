using Domain.Booking.ValueObjects;
using Domain.Common.Primitives;

namespace Domain.Booking.Entities;

public sealed class BookingStatus : Entity<BookingStatusId>
{
    private BookingStatus(BookingStatusId bookingStatusId) : base(bookingStatusId)
    {
    }

    public string Name { get; set; } = string.Empty;

    public static readonly BookingStatus Pending = new(new BookingStatusId(Guid.NewGuid()));
    public static readonly BookingStatus Paid = new(new BookingStatusId(Guid.NewGuid()));
    public static readonly BookingStatus Created = new(new BookingStatusId(Guid.NewGuid()));

    public override string? ToString() => base.ToString();
    public override bool Equals(object? obj) => base.Equals(obj);
    public override int GetHashCode() => base.GetHashCode();
}
