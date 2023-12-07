using Application.Abstractions.Messaging;
using Application.Users;
using Domain.Booking.Enums;
using Domain.Booking.ValueObjects;
using Domain.Common.Shared;
using Domain.User.ValueObjects;

namespace Application.Bookings.BookingManagement.BookingManagementCommands.CancelBooking;
internal sealed class CancelBookingCommandHandler(
    IBookingRepository bookingRepository,
    IUserRepository userRepository) : ICommandHandler<CancelBookingCommand, BookingCommandResult>
{
    public async Task<Result<BookingCommandResult>> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await bookingRepository.GetByIdAsync(BookingId.Create(request.BookingId));
        if (booking is null)
        {
            return (Result<BookingCommandResult>)Result.Failure(Domain.Booking.Exceptions.DomainException.Booking.InvalidBookingId);
        }

        var user = await userRepository.GetByIdAsync(UserId.Create(request.UserId));
        if (user is null)
        {
            //return (Result<BookingCommandResult>)Result.Failure(Domain.Booking.Exceptions.DomainException.User.UserNotFound);
            throw new InvalidOperationException("user doesn't exist");
        }

        booking.UpdateStatus(BookingStatus.Cancelled);

        var updatestatus = bookingRepository.UpdateAsync(booking);

        Task.WaitAll(new Task[] { updatestatus },
                     cancellationToken);

        return new BookingCommandResult(updatestatus.Result);
    }
}
