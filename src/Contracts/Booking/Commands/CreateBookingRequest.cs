namespace Contracts.Booking.Commands;

public record CreateBookingRequest(
    Guid UserId,
    DateTime FromDate,
    DateTime ToDate,
    int Floor,
    int BedCount);

