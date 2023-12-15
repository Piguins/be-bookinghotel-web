namespace Application.Bookings.Commands.ConfirmBooking;

public record ConfirmBookingCommand(
    Guid BookingId) : ICommand<BookingResult>;
