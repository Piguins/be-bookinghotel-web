using Application.Abstractions.Persistence;
using Domain.Rooms.ValueObjects;

namespace Application.Rooms.Commands.DeleteRoom;
internal sealed class DeleteRoomCommandHandler(
    IRoomRepository roomRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : ICommandHandler<DeleteRoomCommand, RoomResult>
{
    public async Task<Result<RoomResult>> Handle(
        DeleteRoomCommand request,
        CancellationToken cancellationToken)
    {
        if (await roomRepository.GetByIdAsync(RoomId.Create(request.RoomId), cancellationToken) is not { } room)
        {
            return Result.Failure<RoomResult>(DomainException.Room.RoomNotFound);
        }

        roomRepository.Remove(room);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<RoomResult>(room);
    }
}
