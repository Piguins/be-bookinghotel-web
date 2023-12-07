using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Domain.Common.Shared;
using Domain.RoomType;

namespace Application.RoomTypes.Queries.GetAllRoomType;
internal sealed class GetAllRoomTypeQueryHandler(IRoomTypeRepository roomTypeRepository) : IQueryHandler<GetAllRoomTypeQuery, RoomTypeQueryResult>
{
    public async Task<Result<RoomTypeQueryResult>> Handle(GetAllRoomTypeQuery request, CancellationToken cancellationToken)
    {
        var getAll = roomTypeRepository.GetAllAsync();

        Task.WaitAll(new Task[] { getAll },
            cancellationToken);

        return new RoomTypeQueryResult(getAll.Result.ToList());
    }
}
