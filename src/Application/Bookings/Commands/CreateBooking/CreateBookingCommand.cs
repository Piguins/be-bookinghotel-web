using Application.Abstractions.Mediator;

namespace Application.Bookings.Commands.CreateBooking;

public record CreateBookingCommand(
    Guid UserId,
    Guid RoomTypeId,
    DateTime FromDate,
    DateTime ToDate,
    int RoomCount) : ICommand<BookingResult>;
