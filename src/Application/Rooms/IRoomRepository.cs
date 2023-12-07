using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Persistence;
using Domain.Room;
using Domain.Room.ValueObjects;

namespace Application.Rooms;
public interface IRoomRepository : IRepository<Room,RoomId>
{
    public Task<List<Room>> GetByRoomTypeIdAsync(Guid roomTypeId);
}
