using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Application.Bookings.BookingManagement;
using Application.RoomTypes;
using Application.Users;
using Domain.Booking;
using Domain.Common.Shared;
using Domain.RoomType;
using Domain.RoomType.ValueObjects;
using Domain.User;
using Domain.User.ValueObjects;

namespace Application.Bookings.BookingManagement.CreateBooking;
internal sealed class CreateBookingCommandHandler(
    IBookingRepository bookingRepository,
    IUserRepository userRepository,
    IRoomTypeRepository roomTypeRepository) : ICommandHandler<CreateBookingCommand, BookingResult>
{
    public async Task<Result<BookingResult>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var realUserId = UserId.Create(request.UserId);
        if (await userRepository.GetByIdAsync(realUserId) is not User)
        {
            throw new InvalidOperationException("User doesn't exist");
        }

        var realRoomTypeId = RoomTypeId.Create(request.RoomTypeId);
        if (await roomTypeRepository.GetByIdAsync(realRoomTypeId) is not RoomType)
        {
            throw new InvalidOperationException("RoomType doesn't exist");
        }

        var booking = Booking.Create(realUserId, realRoomTypeId, request.FromDate, request.ToDate, request.RoomCount);

        var add = bookingRepository.AddAsync(booking);

        Task.WaitAll(new Task[] { add },
                     cancellationToken);

        return new BookingResult(booking);
    }
}
