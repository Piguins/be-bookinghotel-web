namespace Application.Bookings.Commands.CreateBooking;

public record CreateBookingCommand(
    Guid UserId,
    DateTime FromDate,
    DateTime ToDate,
    int Floor,
    int BedCount) : ICommand<BookingResult>;
