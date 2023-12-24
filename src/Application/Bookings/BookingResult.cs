using Application.Users;

namespace Application.Bookings;

public record BookingResult(
    Guid Id,
    Guid OrderId,
    DateTime FromDate,
    DateTime ToDate,
    string Floor,
    int BedCount,
    UserResult User);
