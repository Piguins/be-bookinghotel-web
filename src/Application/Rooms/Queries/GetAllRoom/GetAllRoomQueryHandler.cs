namespace Application.Rooms.Queries.GetAllRoom;

internal sealed class GetAllRoomQueryHandler(
    IRoomRepository roomRepository,
    IMapper mapper) : IQueryHandler<GetAllRoomQuery, ICollection<RoomResult>>
{
    public async Task<Result<ICollection<RoomResult>>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
    {
        var rooms = await roomRepository.GetAllAsync();

        if (request.MinPrice > 0 && request.MaxPrice > 0)
        {
            // rooms = rooms.Where(x => x.Price.Amount >= request.MinPrice && x.Price.Amount <= request.MaxPrice);
            return rooms
                    .Where(x => x.Price.Amount >= request.MinPrice)
                    .Select(mapper.Map<RoomResult>).ToList();
        }
        else if (request.MinPrice > 0)
        {
            return rooms
                    .Where(x => x.Price.Amount >= request.MinPrice)
                    .Select(mapper.Map<RoomResult>).ToList();
        }
        else if (request.MaxPrice > 0)
        {
            return rooms
                    .Where(x => x.Price.Amount <= request.MaxPrice)
                    .Select(mapper.Map<RoomResult>).ToList();
        }

        return rooms.Select(mapper.Map<RoomResult>).ToList();
    }
}
