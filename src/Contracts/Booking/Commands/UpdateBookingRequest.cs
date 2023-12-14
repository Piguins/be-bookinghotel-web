namespace Contracts.Booking.Commands;

public record UpdateBookingRequest(
    Guid BookingId,
    DateTime FromDate,
    DateTime ToDate,
    int? Floor,
    int? BedCount);
