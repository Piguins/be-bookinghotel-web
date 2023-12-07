using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Persistence;
using Application.Rooms;
using Domain.Room;
using Domain.Room.ValueObjects;
using Domain.RoomType.ValueObjects;

namespace Infrastructure.Services.Repositories;
public class RoomRepository : IRoomRepository
{
    private static readonly List<Room> Rooms = new();
    public Task<Room> AddAsync(Room aggregate) => 
        Task.Run(() =>
    {
        Rooms.Add(aggregate);
        return aggregate;
    });
    public Task DeleteAsync(RoomId id) =>
        Task.Run(() =>
        {
            Rooms.Remove(Rooms.FirstOrDefault(room => room.Id.Equals(id)));
        });
    public Task<IEnumerable<Room>> GetAllAsync() =>
        Task.Run(() =>
        {
            return (IEnumerable<Room>)Rooms;
        });
    public Task<Room?> GetByIdAsync(RoomId id) => 
        Task.Run(() =>
    {
        return Rooms.FirstOrDefault(room => room.Id.Equals(id));
    });
    public Task<List<Room>> GetByRoomTypeIdAsync(Guid roomTypeId)
    {
        return Task.Run(() =>
        {
            var result = Rooms.FindAll(x => x.RoomTypeId.Equals(RoomTypeId.Create(roomTypeId)));
            return result;
        });
    }
    public Task<Room?> UpdateAsync(Room aggregate) =>
        Task.Run(() =>
    {
        var room = Rooms.FirstOrDefault(room => room.Id.Equals(aggregate.Id));
        if (room != null)
        {
            room.Update(
                aggregate.Name,
                aggregate.IsReserved,
                aggregate.RoomTypeId);
        }
        return room;
    });
}
