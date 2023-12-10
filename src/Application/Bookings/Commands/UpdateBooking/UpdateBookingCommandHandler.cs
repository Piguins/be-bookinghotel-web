using Application.RoomTypes;
using Application.Users;
using Domain.Booking;
using Domain.Booking.ValueObjects;
using Domain.RoomType.ValueObjects;
using Domain.User.ValueObjects;

namespace Application.Bookings.Commands.UpdateBooking;

internal sealed class UpdateBookingCommandHandler(
    IMapper mapper,
    IBookingRepository bookingRepository,
    IUserRepository userRepository,
    IRoomTypeRepository roomTypeRepository) : ICommandHandler<UpdateBookingCommand, BookingResult>
{
    public async Task<Result<BookingResult>> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
    {
        if (await userRepository.GetByIdAsync(UserId.Create(request.UserId)) is null)
        {
            return Result.Failure<BookingResult>(DomainException.User.UserNotFound);
        }

        if (await roomTypeRepository.GetByIdAsync(RoomTypeId.Create(request.RoomTypeId)) is null)
        {
            return Result.Failure<BookingResult>(DomainException.RoomType.RoomTypeNotFound);
        }

        if (await bookingRepository.GetByIdAsync(BookingId.Create(request.BookingId)) is null)
        {
            return Result.Failure<BookingResult>(DomainException.Booking.BookingNotFound);
        }

        var booking = Booking.Create(request.UserId, request.RoomTypeId, request.FromDate, request.ToDate, request.RoomCount);

        var updateAsync = bookingRepository.UpdateAsync(booking);

        Task.WaitAll(new Task[] { updateAsync },
                     cancellationToken);

        return mapper.Map<BookingResult>(updateAsync.Result);
    }
}
