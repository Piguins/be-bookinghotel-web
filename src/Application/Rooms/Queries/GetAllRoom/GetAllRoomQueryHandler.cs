using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Domain.Common.Shared;
using Domain.Room;

namespace Application.Rooms.Queries.GetAllRoom;
internal sealed class GetAllRoomQueryHandler(IRoomRepository roomRepository) : IQueryHandler<GetAllRoomQuery, RoomQueryResult>
{
    public async Task<Result<RoomQueryResult>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
    {
        var rooms = roomRepository.GetAllAsync();

        Task.WaitAll(new Task[] { rooms }, cancellationToken);

        return new RoomQueryResult(rooms.Result.ToList());
    }
}
