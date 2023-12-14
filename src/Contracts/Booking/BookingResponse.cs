namespace Contracts.Booking;

public record BookingResponse(
    Guid Id,
    Guid UserId,
    DateTime FromDate,
    DateTime ToDate,
    string Floor,
    int BedCount,
    string BookingStatus);

