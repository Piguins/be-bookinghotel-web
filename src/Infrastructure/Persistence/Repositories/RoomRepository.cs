using Application.Rooms;
using Domain.Room;
using Domain.Room.ValueObjects;
using Domain.RoomType.ValueObjects;

namespace Infrastructure.Persistence.Repositories;
public class RoomRepository : IRoomRepository
{
    private static readonly List<Room> Rooms = [];
    public Task<Room> AddAsync(Room aggregate) =>
        Task.Run(() =>
    {
        Rooms.Add(aggregate);
        return aggregate;
    });
    public Task DeleteAsync(RoomId id) =>
        Task.Run(() =>
        {
            if (Rooms.FirstOrDefault(room => room.Id.Equals(id)) is Room room)
            {
                Rooms.Remove(room);
            }
        });
    public Task<IEnumerable<Room>> GetAllAsync() =>
        Task.Run(() => (IEnumerable<Room>)Rooms);
    public Task<Room?> GetByIdAsync(RoomId id) =>
        Task.Run(() =>
    {
        return Rooms.FirstOrDefault(room => room.Id.Equals(id));
    });
    public Task<List<Room>> GetByRoomTypeIdAsync(Guid roomTypeId) =>
        Task.Run(() =>
        {
            var result = Rooms.FindAll(x => x.RoomTypeId.Equals(RoomTypeId.Create(roomTypeId)));
            return result;
        });
    public Task<Room> UpdateAsync(Room aggregate) =>
        Task.Run(() =>
        {
            if (Rooms.FirstOrDefault(room => room.Id.Equals(aggregate.Id)) is Room room)
            {
                // room.Update(
                //     aggregate.Name,
                //     aggregate.IsReserved,
                //     aggregate.RoomTypeId);
                Rooms.Remove(room);
            }
            Rooms.Add(aggregate);
            return aggregate;
        });
}
