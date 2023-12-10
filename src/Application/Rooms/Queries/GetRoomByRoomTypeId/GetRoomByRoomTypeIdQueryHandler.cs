using Application.RoomTypes;
using Domain.RoomType.ValueObjects;

namespace Application.Rooms.Queries.GetRoomByRoomTypeId;
internal sealed class GetRoomByRoomTypeIdQueryHandler(
    IRoomTypeRepository roomTypeRepository,
    IRoomRepository roomRepository) : IQueryHandler<GetRoomByRoomTypeIdQuery, RoomQueryResult>
{
    public async Task<Result<RoomQueryResult>> Handle(GetRoomByRoomTypeIdQuery request, CancellationToken cancellationToken)
    {
        if (Guid.TryParse(request.RoomTypeId, out var guid) is false)
        {
            return Result.Failure<RoomQueryResult>(DomainException.RoomType.RoomTypeIdNotValid);
        }
        if (await roomTypeRepository.GetByIdAsync(RoomTypeId.Create(guid)) is null)
        {
            return Result.Failure<RoomQueryResult>(DomainException.RoomType.RoomTypeNotFound);
        }

        var get = roomRepository.GetByRoomTypeIdAsync(guid);

        Task.WaitAll([get], cancellationToken);

        return new RoomQueryResult([.. get.Result]);
    }
}
