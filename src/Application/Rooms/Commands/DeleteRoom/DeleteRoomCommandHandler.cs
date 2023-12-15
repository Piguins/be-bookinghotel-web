using Domain.Room.ValueObjects;

namespace Application.Rooms.Commands.DeleteRoom;
internal sealed class DeleteRoomCommandHandler(
    IRoomRepository roomRepository,
    IMapper mapper) : ICommandHandler<DeleteRoomCommand, RoomResult>
{
    public async Task<Result<RoomResult>> Handle(
        DeleteRoomCommand request,
        CancellationToken cancellationToken)
    {
        var room = await roomRepository.GetByIdAsync(RoomId.Create(request.RoomId));
        if (room is null)
        {
            return Result.Failure<RoomResult>(DomainException.Room.RoomNotFound);
        }

        var delete = roomRepository.DeleteAsync(room.Id);

        Task.WaitAll([delete], cancellationToken);

        return mapper.Map<RoomResult>(delete);
    }
}
