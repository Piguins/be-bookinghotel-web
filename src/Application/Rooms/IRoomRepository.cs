using Application.Abstractions.Persistence;
using Domain.Common.Enums;
using Domain.Rooms;
using Domain.Rooms.ValueObjects;

namespace Application.Rooms;
public interface IRoomRepository : IRepository<Room, RoomId>
{
    Task<Floor?> GetFloorByIdAsync(int floorId);
}
