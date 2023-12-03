using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Persistence;
using Application.RoomTypes;
using Application.Users;
using Domain.Booking;
using Domain.Common.Shared;
using Domain.RoomType.ValueObjects;
using Domain.User;
using Domain.User.ValueObjects;

namespace Application.Bookings;
public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoomTypeRepository _roomTypeRepository;

    public BookingService(IBookingRepository bookingRepository, IRoomTypeRepository roomTypeRepository, IUserRepository userRepository)
    {
        _bookingRepository = bookingRepository;
        _roomTypeRepository = roomTypeRepository;
        _userRepository = userRepository;
    }

    public BookingResult CancellBooking(Booking booking) => throw new NotImplementedException();
    public BookingResult ChangeBooking(UserId userId, Booking booking) => throw new NotImplementedException();
    public async Task<BookingResult> CreateBooking(
        Guid userId,
        Guid roomTypeId,
        DateTime fromDate,
        DateTime toDate,
        int roomCount)
    {
        var realUserId = UserId.Create(userId);
        if(await _userRepository.GetByIdAsync(realUserId) is null) { throw new InvalidOperationException("User doesn't exist"); }

        var realRoomTypeId = RoomTypeId.Create(roomTypeId);
        if(await _roomTypeRepository.GetByIdAsync(realRoomTypeId) is null) { throw new InvalidOperationException("RoomType doesn't exist"); }

        var booking = Booking.Create(realUserId, realRoomTypeId, fromDate, toDate, roomCount);

        var result = await _bookingRepository.AddAsync(booking);

        return new BookingResult(result);
        
    }
}
