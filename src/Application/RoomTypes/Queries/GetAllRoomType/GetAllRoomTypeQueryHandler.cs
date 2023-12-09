namespace Application.RoomTypes.Queries.GetAllRoomType;

internal sealed class GetAllRoomTypeQueryHandler(IRoomTypeRepository roomTypeRepository) : IQueryHandler<GetAllRoomTypeQuery, RoomTypeQueryResult>
{
    public async Task<Result<RoomTypeQueryResult>> Handle(GetAllRoomTypeQuery request, CancellationToken cancellationToken)
    {
        var getAll = await roomTypeRepository.GetAllAsync();

        return new RoomTypeQueryResult(getAll.ToList());
    }
}
