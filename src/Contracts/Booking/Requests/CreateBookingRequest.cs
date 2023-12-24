namespace Contracts.Booking.Requests;

public record CreateBookingRequest(
    Guid OrderId,
    DateTime FromDate,
    DateTime ToDate,
    int Floor,
    int BedCount);

