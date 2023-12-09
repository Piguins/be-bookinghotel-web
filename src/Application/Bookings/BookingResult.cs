namespace Application.Bookings;

public record BookingResult(
    Guid Id,
    Guid UserId,
    Guid RoomTypeId,
    DateTime FromDate,
    DateTime ToDate,
    int RoomCount,
    string BookingStatus);

public record ListBookingResult(List<BookingResult> Bookings);
