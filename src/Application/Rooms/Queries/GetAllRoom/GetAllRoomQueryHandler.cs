namespace Application.Rooms.Queries.GetAllRoom;

internal sealed class GetAllRoomQueryHandler(
    IRoomRepository roomRepository,
    IMapper mapper) : IQueryHandler<GetAllRoomQuery, ICollection<RoomResult>>
{
    public async Task<Result<ICollection<RoomResult>>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
    {
        var rooms = await roomRepository.GetAllAsync();
        return rooms.Select(mapper.Map<RoomResult>).ToList();
    }
}
