using Application.RoomTypes;
using Domain.RoomType;
using Domain.RoomType.ValueObjects;

namespace Infrastructure.Persistence.Repositories;
public class RoomTypeRepository : IRoomTypeRepository
{
    private static readonly List<RoomType> RoomTypes = [];
    public Task<RoomType> AddAsync(RoomType aggregate) =>
        Task.Run(() =>
        {
            RoomTypes.Add(aggregate);
            return aggregate;
        });
    public Task DeleteAsync(RoomTypeId id) =>
        Task.Run(() =>
        {
            if (RoomTypes.FirstOrDefault(room => room.Id.Equals(id)) is RoomType room)
            {
                RoomTypes.Remove(room);
            }
        });
    public Task<IEnumerable<RoomType>> GetAllAsync() =>
        Task.Run(() =>
        {
            return (IEnumerable<RoomType>)RoomTypes;
        });
    public Task<RoomType?> GetByIdAsync(RoomTypeId id) => Task.Run(() =>
    {
        return RoomTypes.FirstOrDefault(roomtype => roomtype.Id.Equals(id));
    });
    public Task<RoomType> UpdateAsync(RoomType aggregate) => throw new NotImplementedException();
}
