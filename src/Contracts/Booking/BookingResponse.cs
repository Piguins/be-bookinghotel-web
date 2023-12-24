namespace Contracts.Booking;

public record BookingResponse(
    Guid Id,
    Guid UserId,
    Guid OrderId,
    DateTime FromDate,
    DateTime ToDate,
    string Floor,
    int BedCount);

