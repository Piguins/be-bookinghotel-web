using Application.Bookings;
using Domain.Bookings;
using Domain.Bookings.ValueObjects;
using Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class BookingRepository(ApplicationDbContext dbContext) : Repository<Booking, BookingId>(dbContext), IBookingRepository
{
    public override Task<List<Booking>> GetAllAsync() =>
        dbContext.Bookings
            .Include(x => x.Floor)
            .Include(x => x.User)
            .ToListAsync();

    public override Task<Booking?> GetByIdAsync(BookingId id, CancellationToken cancellationToken = default) =>
        dbContext.Bookings
            .Include(x => x.Floor)
            .Include(x => x.User)
            .FirstOrDefaultAsync(user =>
                user.Id.Equals(id), cancellationToken);

    public Task<List<Booking>> GetByUserIdAsync(Guid userId) =>
        dbContext.Bookings
            .Include(x => x.Floor)
            .Include(x => x.User)
            .Where(x => x.User.Id.Value == userId)
            .ToListAsync();
}



