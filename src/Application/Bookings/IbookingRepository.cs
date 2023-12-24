using Application.Abstractions.Persistence;
using Domain.Bookings;
using Domain.Bookings.ValueObjects;

namespace Application.Bookings;

public interface IBookingRepository : IRepository<Booking, BookingId>
{
    Task<List<Booking>> GetByUserIdAsync(Guid userId);
}
