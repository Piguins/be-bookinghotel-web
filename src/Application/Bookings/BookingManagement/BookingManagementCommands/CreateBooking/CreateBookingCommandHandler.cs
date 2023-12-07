using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Application.RoomTypes;
using Application.Users;
using Domain.Booking;
using Domain.Common.Shared;
using Domain.RoomType;
using Domain.RoomType.ValueObjects;
using Domain.User;
using Domain.User.Exceptions;
using Domain.User.ValueObjects;

namespace Application.Bookings.BookingManagement.BookingManagementCommands.CreateBooking;
internal sealed class CreateBookingCommandHandler(
    IBookingRepository bookingRepository,
    IUserRepository userRepository,
    IRoomTypeRepository roomTypeRepository) : ICommandHandler<CreateBookingCommand, BookingCommandResult>
{
    public async Task<Result<BookingCommandResult>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        if (await userRepository.GetByIdAsync(UserId.Create(request.UserId)) is not User)
        {
            return (Result<BookingCommandResult>)Result.Failure(DomainException.User.UserNotFound);
        }

        if (await roomTypeRepository.GetByIdAsync(RoomTypeId.Create(request.RoomTypeId)) is not RoomType)
        {
            throw new InvalidOperationException("RoomType doesn't exist");
        }

        var booking = Booking.Create(request.UserId, request.RoomTypeId, request.FromDate, request.ToDate, request.RoomCount);

        var add = bookingRepository.AddAsync(booking);

        Task.WaitAll(new Task[] { add },
                     cancellationToken);

        return new BookingCommandResult(add.Result);
    }
}
