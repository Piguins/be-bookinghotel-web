using Application.Abstractions.Persistence;
using Domain.Room;
using Domain.Room.ValueObjects;

namespace Application.Rooms;
public interface IRoomRepository : IRepository<Room, RoomId>
{
}
