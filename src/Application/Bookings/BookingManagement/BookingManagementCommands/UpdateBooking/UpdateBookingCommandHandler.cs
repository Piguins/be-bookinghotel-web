using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Application.RoomTypes;
using Application.Users;
using Domain.Booking;
using Domain.Booking.ValueObjects;
using Domain.Common.Shared;
using Domain.RoomType;
using Domain.RoomType.ValueObjects;
using Domain.User;
using Domain.User.Exceptions;
using Domain.Booking.Exceptions;
using Domain.User.ValueObjects;

namespace Application.Bookings.BookingManagement.BookingManagementCommands.UpdateBooking;
internal sealed class UpdateBookingCommandHandler(
    IBookingRepository bookingRepository,
    IUserRepository userRepository,
    IRoomTypeRepository roomTypeRepository) : ICommandHandler<UpdateBookingCommand, BookingCommandResult>
{
    public async Task<Result<BookingCommandResult>> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
    {
        if (await userRepository.GetByIdAsync(UserId.Create(request.UserId)) is null)
        {
            return (Result<BookingCommandResult>)Result.Failure(Domain.User.Exceptions.DomainException.User.UserNotFound) ;
        }

        if (await roomTypeRepository.GetByIdAsync(RoomTypeId.Create(request.RoomTypeId)) is null)
        {
            throw new InvalidOperationException("RoomType doesn't exist");
        }

        if (await bookingRepository.GetByIdAsync(BookingId.Create(request.BookingId)) is null)
        {
            return (Result<BookingCommandResult>)Result.Failure(Domain.Booking.Exceptions.DomainException.Booking.BookingNotFound);
        }

        var booking = Booking.Create(request.UserId, request.RoomTypeId, request.FromDate, request.ToDate, request.RoomCount);

        var update = bookingRepository.UpdateAsync(booking);

        Task.WaitAll(new Task[] { update },
                     cancellationToken);

        return new BookingCommandResult(update.Result);
    }
}
