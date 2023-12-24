using Domain.Rooms.ValueObjects;

namespace Application.Rooms.Queries.GetRoom;

internal sealed class GetRoomQueryHandler(IRoomRepository roomRepository, IMapper mapper)
    : IQueryHandler<GetRoomQuery, RoomResult>
{
    public async Task<Result<RoomResult>> Handle(
        GetRoomQuery request,
        CancellationToken cancellationToken
    ) =>
        await roomRepository.GetByIdAsync(RoomId.Create(request.RoomId)) is not { } room
            ? Result.Failure<RoomResult>(DomainException.Room.RoomNotFound)
            : (Result<RoomResult>)mapper.Map<RoomResult>(room);
}
