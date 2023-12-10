namespace Contracts.Booking.Commands;

public record CreateBookingRequest(
    Guid UserId,
    Guid RoomTypeId,
    DateTime FromDate,
    DateTime ToDate,
    int RoomCount);
