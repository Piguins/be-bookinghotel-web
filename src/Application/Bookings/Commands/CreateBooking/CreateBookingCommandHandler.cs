using Application.Users;
using Domain.Booking;
using Domain.Common.Enums;
using Domain.User.ValueObjects;

namespace Application.Bookings.Commands.CreateBooking;

internal sealed class CreateBookingCommandHandler(
    IMapper mapper,
    IBookingRepository bookingRepository,
    IUserRepository userRepository) : ICommandHandler<CreateBookingCommand, BookingResult>
{
    public async Task<Result<BookingResult>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        if (await userRepository.GetByIdAsync(UserId.Create(request.UserId)) is null)
        {
            return Result.Failure<BookingResult>(DomainException.User.UserNotFound);
        }
        if (Floor.FromValue(request.Floor) is not { } floor)
        {
            return Result.Failure<BookingResult>(DomainException.Room.InvalidFloor);
        }

        var booking = Booking.Create(
                        request.UserId,
                        request.FromDate,
                        request.ToDate,
                        floor,
                        request.BedCount);

        var createAsync = bookingRepository.AddAsync(booking);

        Task.WaitAll([createAsync],
                     cancellationToken);

        return mapper.Map<BookingResult>(createAsync.Result);
    }
}
