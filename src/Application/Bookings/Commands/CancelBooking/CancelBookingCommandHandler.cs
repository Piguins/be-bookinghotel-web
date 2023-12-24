using Domain.Bookings.ValueObjects;

namespace Application.Bookings.Commands.CancelBooking;

internal sealed class CancelBookingCommandHandler(
    IMapper mapper,
    IBookingRepository bookingRepository) : ICommandHandler<CancelBookingCommand, BookingResult>
{
    public async Task<Result<BookingResult>> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
    {
        if (await bookingRepository.GetByIdAsync(BookingId.Create(request.BookingId), cancellationToken) is not { } booking)
        {
            return Result.Failure<BookingResult>(DomainException.Booking.InvalidBookingId);
        }

        // booking.UpdateStatus(BookingStatus.Cancelled);

        var cancel = bookingRepository.Update(booking);

        return mapper.Map<BookingResult>(cancel);
    }
}
