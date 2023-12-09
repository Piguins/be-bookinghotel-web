using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Mediator;
using Application.RoomTypes;
using Domain.Common.Shared;
using Domain.Room;
using Domain.Room.ValueObjects;
using Domain.RoomType.ValueObjects;

namespace Application.Rooms.Commands.UpdateRoom;
internal sealed class UpdateRoomCommandHandler(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository) : ICommandHandler<UpdateRoomCommand, RoomCommandResult>
{
    public async Task<Result<RoomCommandResult>> Handle(
        UpdateRoomCommand request,
        CancellationToken cancellationToken)
    {
        if (await roomTypeRepository.GetByIdAsync(RoomTypeId.Create(request.RoomTypeId)) is null)
        {
            throw new InvalidOperationException("RoomType doesn't exist");
        }

        var room = await roomRepository.GetByIdAsync(RoomId.Create(request.RoomId));
        if(room is null)
        {
            throw new InvalidOperationException("Room doesn't exist");
        }

        var update = roomRepository.UpdateAsync(room);

        Task.WaitAll(new Task[] { update }, cancellationToken);

        return new RoomCommandResult(update.Result);
    }
}
