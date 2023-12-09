namespace Contracts.Booking.Commands;

public record CancelBookingRequest(
    Guid BookingId,
    Guid UserId);
