using Domain.Common.Enums;
using Domain.Room.ValueObjects;

namespace Application.Rooms.Commands.UpdateRoom;
internal sealed class UpdateRoomCommandHandler(IRoomRepository roomRepository) : ICommandHandler<UpdateRoomCommand, RoomCommandResult>
{
    public async Task<Result<RoomCommandResult>> Handle(
        UpdateRoomCommand request,
        CancellationToken cancellationToken)
    {
        if (await roomRepository.GetByIdAsync(RoomId.Create(request.RoomId)) is not { } room)
        {
            return Result.Failure<RoomCommandResult>(DomainException.Room.RoomNotFound);
        }

        room.Update(
            request.Name,
            request.IsReserved,
            !request.Floor.HasValue ? null : Floor.FromValue(request.Floor.Value),
            request.BedCount,
            request.Amount,
            request.Currency);
        var update = roomRepository.UpdateAsync(room);

        Task.WaitAll([update], cancellationToken);

        return new RoomCommandResult(update.Result);
    }
}
