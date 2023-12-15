using Domain.Booking.Enums;
using Domain.Booking.ValueObjects;

namespace Application.Bookings.Commands.CancelBooking;

internal sealed class CancelBookingCommandHandler(
    IMapper mapper,
    IBookingRepository bookingRepository) : ICommandHandler<CancelBookingCommand, BookingResult>
{
    public async Task<Result<BookingResult>> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
    {
        if (await bookingRepository.GetByIdAsync(BookingId.Create(request.BookingId)) is not { } booking)
        {
            return Result.Failure<BookingResult>(DomainException.Booking.InvalidBookingId);
        }

        booking.UpdateStatus(BookingStatus.Cancelled);

        var cancelAsync = bookingRepository.UpdateAsync(booking);

        Task.WaitAll([cancelAsync],
                     cancellationToken);

        return mapper.Map<BookingResult>(cancelAsync.Result);
    }
}
