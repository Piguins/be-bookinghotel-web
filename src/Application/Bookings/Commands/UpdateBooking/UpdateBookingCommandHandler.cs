using Domain.Booking.Enums;
using Domain.Booking.ValueObjects;
using Domain.Common.Enums;

namespace Application.Bookings.Commands.UpdateBooking;

internal sealed class UpdateBookingCommandHandler(
    IMapper mapper,
    IBookingRepository bookingRepository) : ICommandHandler<UpdateBookingCommand, BookingResult>
{
    public async Task<Result<BookingResult>> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
    {
        if (await bookingRepository.GetByIdAsync(BookingId.Create(request.BookingId)) is not { } booking)
        {
            return Result.Failure<BookingResult>(DomainException.Booking.BookingNotFound);
        }
        if (booking.BookingStatus == BookingStatus.Cancelled)
        {
            return Result.Failure<BookingResult>(DomainException.Booking.BookingIsCancelled);
        }
        if (booking.BookingStatus == BookingStatus.Confirmed)
        {
            return Result.Failure<BookingResult>(DomainException.Booking.BookingIsConfirmed);
        }

        booking.Update(
            request.FromDate,
            request.ToDate,
            !request.Floor.HasValue ? null : Floor.FromValue(request.Floor.Value),
            request.BedCount);

        var updateAsync = bookingRepository.UpdateAsync(booking);

        Task.WaitAll([updateAsync],
                     cancellationToken);

        return mapper.Map<BookingResult>(updateAsync.Result);
    }
}
