namespace Application.Bookings.Commands.CancelBooking;

public record CancelBookingCommand(
    Guid BookingId) : ICommand<BookingResult>;
