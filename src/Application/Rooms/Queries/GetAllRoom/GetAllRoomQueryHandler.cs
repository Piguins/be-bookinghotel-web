namespace Application.Rooms.Queries.GetAllRoom;

internal sealed class GetAllRoomQueryHandler(IRoomRepository roomRepository) : IQueryHandler<GetAllRoomQuery, RoomQueryResult>
{
    public async Task<Result<RoomQueryResult>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
    {
        var rooms = await roomRepository.GetAllAsync();
        return new RoomQueryResult(rooms.ToList());
    }
}
