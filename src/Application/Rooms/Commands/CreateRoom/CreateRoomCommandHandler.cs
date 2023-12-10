using Application.RoomTypes;
using Domain.Room;
using Domain.RoomType.ValueObjects;

namespace Application.Rooms.Commands.CreateRoom;
internal sealed class CreateRoomCommandHandler(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository) : ICommandHandler<CreateRoomCommand, RoomCommandResult>
{
    public async Task<Result<RoomCommandResult>> Handle(
        CreateRoomCommand request,
        CancellationToken cancellationToken)
    {
        if (await roomTypeRepository.GetByIdAsync(RoomTypeId.Create(request.RoomTypeId)) is null)
        {
            return Result.Failure<RoomCommandResult>(DomainException.RoomType.RoomTypeNotFound);
        }

        var room = Room.Create(
            request.Name,
            false,
            request.RoomTypeId);

        var add = roomRepository.AddAsync(room);

        Task.WaitAll([add], cancellationToken);

        return new RoomCommandResult(add.Result);
    }
}
