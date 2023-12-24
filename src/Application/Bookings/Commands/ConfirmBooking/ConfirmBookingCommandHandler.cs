using Domain.Bookings.ValueObjects;

namespace Application.Bookings.Commands.ConfirmBooking;

internal sealed class ConfirmBookingCommandHandler(
    IMapper mapper,
    IBookingRepository bookingRepository) : ICommandHandler<ConfirmBookingCommand, BookingResult>
{
    public async Task<Result<BookingResult>> Handle(ConfirmBookingCommand request, CancellationToken cancellationToken)
    {
        if (await bookingRepository.GetByIdAsync(BookingId.Create(request.BookingId), cancellationToken) is not { } booking)
        {
            return Result.Failure<BookingResult>(DomainException.Booking.InvalidBookingId);
        }
        // if (booking.BookingStatus == BookingStatus.Cancelled)
        // {
        //     return Result.Failure<BookingResult>(DomainException.Booking.BookingIsCancelled);
        // }
        //
        // booking.UpdateStatus(BookingStatus.Confirmed);

        var confirm = bookingRepository.Update(booking);

        return mapper.Map<BookingResult>(confirm);
    }
}
