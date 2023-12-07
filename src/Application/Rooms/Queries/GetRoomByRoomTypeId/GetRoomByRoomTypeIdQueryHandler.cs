using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Application.RoomTypes;
using Domain.Common.Shared;
using Domain.RoomType.ValueObjects;

namespace Application.Rooms.Queries.GetRoomByRoomTypeId;
internal sealed class GetRoomByRoomTypeIdQueryHandler(
    IRoomTypeRepository roomTypeRepository,
    IRoomRepository roomRepository) : IQueryHandler<GetRoomByRoomTypeIdQuery, RoomQueryResult>
{
    public async Task<Result<RoomQueryResult>> Handle(GetRoomByRoomTypeIdQuery request, CancellationToken cancellationToken)
    {
        if (await roomTypeRepository.GetByIdAsync(RoomTypeId.Create(request.RoomTypeId)) is null)
        {
            throw new InvalidOperationException("RoomType doesn't exist");
        }

        var get = roomRepository.GetByRoomTypeIdAsync(request.RoomTypeId);

        Task.WaitAll(new Task[] { get }, cancellationToken);

        return new RoomQueryResult(get.Result.ToList());
    }
}
