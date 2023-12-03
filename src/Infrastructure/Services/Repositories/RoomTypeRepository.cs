using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.RoomTypes;
using Domain.RoomType;
using Domain.RoomType.ValueObjects;

namespace Infrastructure.Services.Repositories;
public class RoomTypeRepository : IRoomTypeRepository
{
    private static readonly List<RoomType> RoomType = new();
    public Task<RoomType> AddAsync(RoomType aggregate) => throw new NotImplementedException();
    public Task DeleteAsync(RoomTypeId id) => throw new NotImplementedException();
    public Task<IEnumerable<RoomType>> GetAllAsync() => throw new NotImplementedException();
    public Task<RoomType?> GetByIdAsync(RoomTypeId id) => Task.Run(() =>
    {
        return RoomType.FirstOrDefault(roomtype => roomtype.Id.Equals(id));
    });
    public Task<RoomType> UpdateAsync(RoomType aggregate) => throw new NotImplementedException();
}
