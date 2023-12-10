using Application.RoomTypes;
using Domain.Room.ValueObjects;
using Domain.RoomType.ValueObjects;

namespace Application.Rooms.Commands.UpdateRoom;
internal sealed class UpdateRoomCommandHandler(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository) : ICommandHandler<UpdateRoomCommand, RoomCommandResult>
{
    public async Task<Result<RoomCommandResult>> Handle(
        UpdateRoomCommand request,
        CancellationToken cancellationToken)
    {
        if (await roomRepository.GetByIdAsync(RoomId.Create(request.RoomId)) is not { } room)
        {
            return Result.Failure<RoomCommandResult>(DomainException.Room.RoomNotFound);
        }
        if (request.RoomTypeId.HasValue
            && await roomTypeRepository.GetByIdAsync(RoomTypeId.Create((Guid)request.RoomTypeId)) is null)
        {
            return Result.Failure<RoomCommandResult>(DomainException.RoomType.RoomTypeNotFound);
        }

        room.Update(
            request.Name,
            request.IsReserved,
            !request.RoomTypeId.HasValue ? null : RoomTypeId.Create((Guid)request.RoomTypeId));
        var update = roomRepository.UpdateAsync(room);

        Task.WaitAll([update], cancellationToken);

        return new RoomCommandResult(update.Result);
    }
}
