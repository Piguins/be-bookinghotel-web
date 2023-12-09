namespace Contracts.Booking.Commands;

public record UpdateBookingRequest(
    Guid UserId,
    Guid BookingId,
    Guid RoomTypeId,
    DateTime FromDate,
    DateTime ToDate,
    int RoomCount);
