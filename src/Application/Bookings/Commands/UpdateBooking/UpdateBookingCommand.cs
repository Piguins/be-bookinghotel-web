namespace Application.Bookings.Commands.UpdateBooking;

public record UpdateBookingCommand(
    Guid BookingId,
    DateTime? FromDate,
    DateTime? ToDate,
    int? Floor,
    int? BedCount) : ICommand<BookingResult>;
