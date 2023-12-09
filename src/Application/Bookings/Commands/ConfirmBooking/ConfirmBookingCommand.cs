namespace Application.Bookings.Commands.ConfirmBooking;

public record ConfirmBookingCommand(
    Guid BookingId,
    Guid UserId) : ICommand<BookingResult>;
