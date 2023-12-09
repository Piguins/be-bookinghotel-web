using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Mediator;
using Application.Rooms.Commands.CreateRoom;
using Application.RoomTypes;
using Domain.Common.Shared;
using Domain.Room;
using Domain.Room.ValueObjects;
using Domain.RoomType.ValueObjects;

namespace Application.Rooms.Commands.DeleteRoom;
internal sealed class DeleteRoomCommandHandler(IRoomRepository roomRepository) : ICommandHandler<DeleteRoomCommand, RoomCommandResult>
{
    public async Task<Result<RoomCommandResult>> Handle(
        DeleteRoomCommand request,
        CancellationToken cancellationToken)
    {
        var room = await roomRepository.GetByIdAsync(RoomId.Create(request.RoomId));
        if (room is null)
        {
            throw new InvalidOperationException("Room doesn't exist");
        }

        var delete = roomRepository.DeleteAsync(room.Id);

        Task.WaitAll(new Task[] { delete }, cancellationToken);

        return new RoomCommandResult(room);
    }
}
