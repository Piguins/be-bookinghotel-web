using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Persistence;
using Domain.Booking;
using Domain.User.ValueObjects;

namespace Application.BookingManagement;
public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public BookingResult CancellBooking(Booking booking) => throw new NotImplementedException();
    public BookingResult ChangeBooking(UserId userId, Booking booking) => throw new NotImplementedException();
    public BookingResult CreateBooking(
        string userId,
        string roomTypeId,
        string fromDate,
        string toDate,
        string roomCount)
    {

    }
}
