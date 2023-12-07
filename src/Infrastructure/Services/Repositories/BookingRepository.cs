using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Bookings;
using Domain.Booking;
using Domain.Booking.ValueObjects;
using Domain.User.ValueObjects;

namespace Infrastructure.Services.Repositories;
public class BookingRepository : IBookingRepository
{
    private static readonly List<Booking> Bookings = new();
    public Task<Booking> AddAsync(Booking aggregate) => Task.Run(() =>
    {
        Bookings.Add(aggregate);
        return aggregate;
    });
    public Task DeleteAsync(BookingId id) => throw new NotImplementedException();
    public Task<IEnumerable<Booking>> GetAllAsync() => throw new NotImplementedException();
    public Task<List<Booking>> GetByUserIdAsync(Guid userId)
    {
        return Task.Run(() =>
        {
            var result = Bookings.FindAll(x => x.UserId.Equals(UserId.Create(userId)));
            return result;
        });
    }
    public Task<Booking?> GetByIdAsync(BookingId id)
    {
        return Task.Run(() =>
        {
            return Bookings.FirstOrDefault(booking => booking.Id.Equals(id));
        });
    }
    public Task<Booking?> UpdateAsync(Booking aggregate)
    {
        return Task.Run(() =>
        {
            var booking = Bookings.FirstOrDefault(booking => booking.Id.Equals(aggregate.Id));
            if(booking != null)
            {
                booking.Update(
                    aggregate.UserId,
                    aggregate.RoomTypeId,
                    aggregate.FromDate,
                    aggregate.EndDate,
                    aggregate.RoomCount);
            }
            return booking;
        });
    }
}
