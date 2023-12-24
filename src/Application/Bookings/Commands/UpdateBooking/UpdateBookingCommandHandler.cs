using Application.Abstractions.Persistence;
using Application.Rooms;
using Domain.Bookings.ValueObjects;
using Domain.Common.Enums;

namespace Application.Bookings.Commands.UpdateBooking;

internal sealed class UpdateBookingCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IRoomRepository roomRepository,
    IBookingRepository bookingRepository) : ICommandHandler<UpdateBookingCommand, BookingResult>
{
    public async Task<Result<BookingResult>> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
    {
        if (await bookingRepository.GetByIdAsync(BookingId.Create(request.BookingId), cancellationToken) is not { } booking)
        {
            return Result.Failure<BookingResult>(DomainException.Booking.BookingNotFound);
        }
        Floor? floor = null;
        if (request.Floor.HasValue)
        {
            if (await roomRepository.GetFloorByIdAsync(request.Floor.Value) is not { } value)
            {
                return Result.Failure<BookingResult>(DomainException.Room.InvalidFloor);
            }
            floor = value;
        }
        // if (booking.BookingStatus == BookingStatus.Cancelled)
        // {
        //     return Result.Failure<BookingResult>(DomainException.Booking.BookingIsCancelled);
        // }
        // if (booking.BookingStatus == BookingStatus.Confirmed)
        // {
        //     return Result.Failure<BookingResult>(DomainException.Booking.BookingIsConfirmed);
        // }

        booking.Update(
            request.FromDate,
            request.ToDate,
            request.Floor.HasValue ? floor : null,
            request.BedCount);

        var update = bookingRepository.Update(booking);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<BookingResult>(update);
    }
}
