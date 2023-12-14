using Domain.Booking.Enums;
using Domain.Booking.ValueObjects;

namespace Application.Bookings.Commands.ConfirmBooking;

internal sealed class ConfirmBookingCommandHandler(
    IMapper mapper,
    IBookingRepository bookingRepository) : ICommandHandler<ConfirmBookingCommand, BookingResult>
{
    public async Task<Result<BookingResult>> Handle(ConfirmBookingCommand request, CancellationToken cancellationToken)
    {
        if (await bookingRepository.GetByIdAsync(BookingId.Create(request.BookingId)) is not { } booking)
        {
            return Result.Failure<BookingResult>(DomainException.Booking.InvalidBookingId);
        }
        if (booking.BookingStatus == BookingStatus.Cancelled)
        {
            return Result.Failure<BookingResult>(DomainException.Booking.BookingIsCancelled);
        }

        booking.UpdateStatus(BookingStatus.Confirmed);

        var confirmAsync = bookingRepository.UpdateAsync(booking);

        Task.WaitAll([confirmAsync],
                     cancellationToken);

        return mapper.Map<BookingResult>(confirmAsync.Result);
    }
}
