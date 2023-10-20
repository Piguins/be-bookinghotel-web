using Domain.Booking.Entities;
using Domain.Booking.ValueObjects;
using Domain.Common.Primitives;

namespace Domain.Booking;

public class Booking : AggregateRoot<BookingId>
{
    public Booking(BookingId bookingId, BookingStatus bookingStatus) : base(bookingId)
    {
        // BookingId = bookingId;
        BookingStatus = bookingStatus;
    }

    // public BookingId BookingId { get; set; }
    public BookingStatus BookingStatus { get; set; }
    public Guid CustomerId { get; set; }
    public Guid AdminId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public uint RoomCount { get; set; } = 1;
}
