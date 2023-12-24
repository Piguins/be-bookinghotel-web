namespace Contracts.Booking.Requests;

public record UpdateBookingRequest(
    Guid BookingId,
    DateTime FromDate,
    DateTime ToDate,
    int? Floor,
    int? BedCount);
