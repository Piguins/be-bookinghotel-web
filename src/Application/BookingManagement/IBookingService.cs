using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Booking;
using Domain.User.ValueObjects;

namespace Application.BookingManagement;
public interface IBookingService
{
    BookingResult CreateBooking(
    string userId,
    string roomTypeId,
    string fromDate,
    string toDate,
    string roomCount);
    BookingResult CancellBooking(Booking booking);
    BookingResult ChangeBooking(UserId userId, Booking booking);
}
