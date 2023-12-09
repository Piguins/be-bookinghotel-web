using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Mediator;
using Application.RoomTypes;
using Domain.Common.Shared;
using Domain.Room;
using Domain.RoomType.ValueObjects;

namespace Application.Rooms.Commands.CreateRoom;
internal sealed class UpdateRoomCommandHandler(IRoomRepository roomRepository,IRoomTypeRepository roomTypeRepository) : ICommandHandler<CreateRoomCommand, RoomCommandResult>
{
    public async Task<Result<RoomCommandResult>> Handle(
        CreateRoomCommand request,
        CancellationToken cancellationToken)
    {
        if(await roomTypeRepository.GetByIdAsync(RoomTypeId.Create(request.RoomTypeId)) is null)
        {
            throw new InvalidOperationException("RoomType doesn't exist");
        }

        var room = Room.Create(
            request.Name,
            request.IsReserved,
            request.RoomTypeId);

        var add = roomRepository.AddAsync(room);

        Task.WaitAll(new Task[] { add }, cancellationToken);

        return new RoomCommandResult(add.Result);
    }
}
