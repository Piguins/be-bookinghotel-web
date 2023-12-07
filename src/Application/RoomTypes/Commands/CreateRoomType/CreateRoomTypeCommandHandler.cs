using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Domain.Common.Shared;
using Domain.RoomType;

namespace Application.RoomTypes.Commands.CreateRoomType;
internal sealed class CreateRoomTypeCommandHandler(IRoomTypeRepository roomTypeRepository) : ICommandHandler<CreateRoomTypeCommand, RoomTypeCommandResult>
{
    public async Task<Result<RoomTypeCommandResult>> Handle(
        CreateRoomTypeCommand request,
        CancellationToken cancellationToken)
    {
        var roomType = RoomType.Create(request.Floor, request.BedCount, request.Amount, request.Currency);

        var add = roomTypeRepository.AddAsync(roomType);

        Task.WaitAll(new Task[] { add }, 
                     cancellationToken);

        return new RoomTypeCommandResult(add.Result);
    }
}
