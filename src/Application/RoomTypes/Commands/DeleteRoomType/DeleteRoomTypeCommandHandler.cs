using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Application.RoomTypes.Commands.DeleteRoomType;
using Domain.Common.Shared;
using Domain.RoomType;
using Domain.RoomType.ValueObjects;

namespace Application.RoomTypes.Commands.DeleteRoomType;
internal sealed class DeleteRoomTypeCommandHandler(IRoomTypeRepository roomTypeRepository) : ICommandHandler<DeleteRoomTypeCommand, RoomTypeCommandResult>
{
    public async Task<Result<RoomTypeCommandResult>> Handle(
        DeleteRoomTypeCommand request,
        CancellationToken cancellationToken)
    {
        var roomType = await roomTypeRepository.GetByIdAsync(RoomTypeId.Create(request.RoomTypeId));
        if (roomType is null)
        {
            throw new InvalidOperationException("RoomType doesn't not exist");
        }



        var delete = roomTypeRepository.DeleteAsync(roomType.Id);

        Task.WaitAll(new Task[] { delete }, 
                     cancellationToken);

        return new RoomTypeCommandResult(roomType);
    }
}
