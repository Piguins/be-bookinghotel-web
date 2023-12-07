using Domain.RoomType;
using Domain.RoomType.ValueObjects;

namespace Infrastructure.Persistence.Repositories;
public class RoomTypeRepository : IRoomTypeRepository
{
    private static readonly List<RoomType> RoomType = new();
    public Task<RoomType> AddAsync(RoomType aggregate) =>
        Task.Run(() =>
        {
            RoomType.Add(aggregate);
            return aggregate;
        });
    public Task DeleteAsync(RoomTypeId id) =>
        Task.Run(() =>
        {
            RoomType.Remove(RoomType.FirstOrDefault(x => x.Id.Equals(id)));
        });
    public Task<IEnumerable<RoomType>> GetAllAsync() =>
        Task.Run(() =>
        {
            return (IEnumerable<RoomType>)RoomType;
        });
    public Task<RoomType?> GetByIdAsync(RoomTypeId id) => Task.Run(() =>
    {
        return RoomType.FirstOrDefault(roomtype => roomtype.Id.Equals(id));
    });
    public Task<RoomType> UpdateAsync(RoomType aggregate) => throw new NotImplementedException();
}
