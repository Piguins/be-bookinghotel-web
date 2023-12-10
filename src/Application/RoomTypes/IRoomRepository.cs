using Application.Abstractions.Persistence;
using Domain.RoomType.ValueObjects;
using Domain.RoomType;

namespace Application.RoomTypes;
public interface IRoomTypeRepository : IRepository<RoomType, RoomTypeId>
{
}
