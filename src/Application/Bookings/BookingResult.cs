namespace Application.Bookings;

public record BookingResult(
    Guid Id,
    Guid UserId,
    DateTime FromDate,
    DateTime ToDate,
    string Floor,
    int BedCount,
    string BookingStatus);
