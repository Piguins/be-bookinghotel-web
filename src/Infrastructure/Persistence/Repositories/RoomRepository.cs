using Application.Rooms;
using Domain.Common.Enums;
using Domain.Rooms;
using Domain.Rooms.ValueObjects;
using Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class RoomRepository(ApplicationDbContext dbContext) : Repository<Room, RoomId>(dbContext), IRoomRepository
{
    public override Task<List<Room>> GetAllAsync() =>
        dbContext.Rooms
            .Include(x => x.Floor)
            .Include(x => x.Images)
            .ToListAsync();

    public override Task<Room?> GetByIdAsync(RoomId id, CancellationToken cancellationToken = default) =>
        dbContext.Rooms
            .Include(x => x.Floor)
            .Include(x => x.Images)
            .FirstOrDefaultAsync(user =>
                user.Id.Equals(id), cancellationToken);

    public Task<Floor?> GetFloorByIdAsync(int floorId) =>
        dbContext.Floors.FirstOrDefaultAsync(x =>
            x.Value == floorId);
}


