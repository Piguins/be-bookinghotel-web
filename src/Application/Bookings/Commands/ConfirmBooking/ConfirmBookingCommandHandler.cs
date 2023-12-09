using Application.Users;
using Domain.Booking.Enums;
using Domain.Booking.ValueObjects;
using Domain.User.Enums;
using Domain.User.ValueObjects;

namespace Application.Bookings.Commands.ConfirmBooking;

internal sealed class ConfirmBookingCommandHandler(
    IMapper mapper,
    IBookingRepository bookingRepository,
    IUserRepository userRepository) : ICommandHandler<ConfirmBookingCommand, BookingResult>
{
    public async Task<Result<BookingResult>> Handle(ConfirmBookingCommand request, CancellationToken cancellationToken)
    {
        if (await bookingRepository.GetByIdAsync(BookingId.Create(request.BookingId)) is not { } booking)
        {
            return Result.Failure<BookingResult>(DomainException.Booking.InvalidBookingId);
        }
        if (await userRepository.GetByIdAsync(UserId.Create(request.UserId)) is not { } user)
        {
            return Result.Failure<BookingResult>(DomainException.User.UserNotFound);
        }
        if (!user.Roles.Contains(Role.Host))
        {
            return Result.Failure<BookingResult>(DomainException.User.InvalidCredentials);
        }

        booking.UpdateStatus(BookingStatus.Confirmed);

        var confirmAsync = bookingRepository.UpdateAsync(booking);

        Task.WaitAll(new Task[] { confirmAsync },
                     cancellationToken);

        return mapper.Map<BookingResult>(confirmAsync.Result);
    }
}
