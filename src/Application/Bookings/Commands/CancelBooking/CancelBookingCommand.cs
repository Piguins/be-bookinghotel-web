using Application.Abstractions.Mediator;

namespace Application.Bookings.Commands.CancelBooking;

public record CancelBookingCommand(
    Guid BookingId,
    Guid UserId) : ICommand<BookingResult>;
