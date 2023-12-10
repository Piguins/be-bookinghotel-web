using Application.Bookings;
using Domain.Booking;
using Domain.Booking.ValueObjects;
using Domain.User.ValueObjects;

namespace Infrastructure.Persistence.Repositories;
public class BookingRepository : IBookingRepository
{
    private static readonly List<Booking> Bookings = [];
    public Task<Booking> AddAsync(Booking aggregate) => Task.Run(() =>
    {
        Bookings.Add(aggregate);
        return aggregate;
    });
    public Task DeleteAsync(BookingId id) => throw new NotImplementedException();
    public Task<IEnumerable<Booking>> GetAllAsync() =>
        Task.Run(() =>
        {
            return Bookings.AsEnumerable();
        });
    public Task<List<Booking>> GetByUserIdAsync(Guid userId) =>
        Task.Run(() =>
        {
            var result = Bookings.FindAll(x => x.UserId.Equals(UserId.Create(userId)));
            return result;
        });

    public Task<Booking?> GetByIdAsync(BookingId id) =>
        Task.Run(() =>
        {
            return Bookings.FirstOrDefault(booking => booking.Id.Equals(id));
        });

    public Task<Booking> UpdateAsync(Booking aggregate) =>
        Task.Run(() =>
        {
            if (Bookings.FirstOrDefault(booking => booking.Id.Equals(aggregate.Id)) is Booking booking)
            {
                // booking.Update(
                //     aggregate.UserId,
                //     aggregate.RoomTypeId,
                //     aggregate.FromDate,
                //     aggregate.EndDate,
                //     aggregate.RoomCount);
                Bookings.Remove(booking);
            }
            Bookings.Add(aggregate);
            return aggregate;
        });
}
