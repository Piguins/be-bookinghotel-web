using Application.Abstractions.Mediator;

namespace Application.Bookings.Commands.UpdateBooking;

public record UpdateBookingCommand(
    Guid UserId,
    Guid BookingId,
    Guid RoomTypeId,
    DateTime FromDate,
    DateTime ToDate,
    int RoomCount) : ICommand<BookingResult>;
