using Application.Abstractions.Persistence;
using Application.Rooms;
using Application.Users;
using Domain.Bookings;
using Domain.Users.ValueObjects;

namespace Application.Bookings.Commands.CreateBooking;

internal sealed class CreateBookingCommandHandler(
    IMapper mapper,
    IBookingRepository bookingRepository,
    IRoomRepository roomRepository,
    IUnitOfWork unitOfWork,
    IUserRepository userRepository) : ICommandHandler<CreateBookingCommand, BookingResult>
{
    public async Task<Result<BookingResult>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        if (await userRepository.GetByIdAsync(UserId.Create(request.UserId), cancellationToken) is not { } user)
        {
            return Result.Failure<BookingResult>(DomainException.User.UserNotFound);
        }
        if (await roomRepository.GetFloorByIdAsync(request.Floor) is not { } floor)
        {
            return Result.Failure<BookingResult>(DomainException.Room.InvalidFloor);
        }

        var booking = Booking.Create(
                        user,
                        request.OrderId,
                        request.FromDate,
                        request.ToDate,
                        floor,
                        request.BedCount);

        var create = bookingRepository.Add(booking);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<BookingResult>(create);
    }
}
