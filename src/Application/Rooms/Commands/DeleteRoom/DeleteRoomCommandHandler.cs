using Domain.Room.ValueObjects;

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
            return Result.Failure<RoomCommandResult>(DomainException.Room.RoomNotFound);
        }

        var delete = roomRepository.DeleteAsync(room.Id);

        Task.WaitAll([delete], cancellationToken);

        return new RoomCommandResult(room);
    }
}
