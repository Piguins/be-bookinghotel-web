namespace Contracts.Booking.Commands;

public record ConfirmBookingRequest(
    Guid BookingId,
    Guid UserId);
