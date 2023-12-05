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
using Domain.User.ValueObjects;

namespace Application.Bookings.BookingManagement.BookingManagementCommands.UpdateBooking;
internal sealed class UpdateBookingCommandHandler(
    IBookingRepository bookingRepository,
    IUserRepository userRepository,
    IRoomTypeRepository roomTypeRepository) : ICommandHandler<UpdateBookingCommand, BookingCommandResult>
{
    public async Task<Result<BookingCommandResult>> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
    {
        var realUserId = UserId.Create(request.UserId);
        if (await userRepository.GetByIdAsync(realUserId) is null)
        {
            throw new InvalidOperationException("User doesn't exist");
        }

        var realRoomTypeId = RoomTypeId.Create(request.RoomTypeId);
        if (await roomTypeRepository.GetByIdAsync(realRoomTypeId) is null)
        {
            throw new InvalidOperationException("RoomType doesn't exist");
        }

        var realBookingValue = BookingId.Create(request.BookingId);
        if (await bookingRepository.GetByIdAsync(realBookingValue) is null)
        {
            throw new InvalidOperationException("Booking doesn't exist");
        }

        var booking = Booking.Create(realUserId, realRoomTypeId, request.FromDate, request.ToDate, request.RoomCount);

        var update = bookingRepository.UpdateAsync(booking);

        Task.WaitAll(new Task[] { update },
                     cancellationToken);

        return new BookingCommandResult(booking);
    }
}
