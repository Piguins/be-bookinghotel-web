namespace Application.Bookings.Commands.CreateBooking;

public record CreateBookingCommand(
    Guid UserId,
    Guid OrderId,
    DateTime FromDate,
    DateTime ToDate,
    int Floor,
    int BedCount) : ICommand<BookingResult>;
