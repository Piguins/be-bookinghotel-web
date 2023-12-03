using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Booking;
using Domain.User.ValueObjects;

namespace Application.Bookings;
public interface IBookingService
{
    public Task<BookingResult> CreateBooking(
    Guid userId,
    Guid roomTypeId,
    DateTime fromDate,
    DateTime toDate,
    int roomCount);
    BookingResult CancellBooking(Booking booking);
    BookingResult ChangeBooking(UserId userId, Booking booking);
}
