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
            return Result.Failure<RoomTypeCommandResult>(DomainException.RoomType.RoomTypeNotFound);
        }

        var deleteAsync = roomTypeRepository.DeleteAsync(roomType.Id);

        Task.WaitAll(new Task[] { deleteAsync },
                     cancellationToken);

        return new RoomTypeCommandResult(roomType);
    }
}
