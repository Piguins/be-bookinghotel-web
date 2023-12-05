using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Persistence;
using Domain.Booking;
using Domain.Booking.ValueObjects;

namespace Application.Bookings;
public interface IBookingRepository : IRepository<Booking, BookingId>
{
    Task<List<Booking>> GetByUserIdAsync(Guid userId);
}
