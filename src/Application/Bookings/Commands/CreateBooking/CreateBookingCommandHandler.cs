using Application.RoomTypes;
using Application.Users;
using Domain.Booking;
using Domain.RoomType.ValueObjects;
using Domain.User.ValueObjects;

namespace Application.Bookings.Commands.CreateBooking;

internal sealed class CreateBookingCommandHandler(
    IMapper mapper,
    IBookingRepository bookingRepository,
    IUserRepository userRepository,
    IRoomTypeRepository roomTypeRepository) : ICommandHandler<CreateBookingCommand, BookingResult>
{
    public async Task<Result<BookingResult>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        if (await userRepository.GetByIdAsync(UserId.Create(request.UserId)) is null)
        {
            return Result.Failure<BookingResult>(DomainException.User.UserNotFound);
        }

        if (await roomTypeRepository.GetByIdAsync(RoomTypeId.Create(request.RoomTypeId)) is null)
        {
            return Result.Failure<BookingResult>(DomainException.RoomType.RoomTypeNotFound);
        }

        var booking = Booking.Create(
                        request.UserId,
                        request.RoomTypeId,
                        request.FromDate,
                        request.ToDate,
                        request.RoomCount);

        var createAsync = bookingRepository.AddAsync(booking);

        Task.WaitAll(new Task[] { createAsync },
                     cancellationToken);

        return mapper.Map<BookingResult>(createAsync.Result);
    }
}
