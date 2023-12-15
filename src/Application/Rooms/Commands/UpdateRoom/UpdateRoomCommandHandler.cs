using Domain.Common.Enums;
using Domain.Room.ValueObjects;

namespace Application.Rooms.Commands.UpdateRoom;
internal sealed class UpdateRoomCommandHandler(
    IRoomRepository roomRepository,
    IMapper mapper) : ICommandHandler<UpdateRoomCommand, RoomResult>
{
    public async Task<Result<RoomResult>> Handle(
        UpdateRoomCommand request,
        CancellationToken cancellationToken)
    {
        if (await roomRepository.GetByIdAsync(RoomId.Create(request.RoomId)) is not { } room)
        {
            return Result.Failure<RoomResult>(DomainException.Room.RoomNotFound);
        }

        room.Update(
            request.Name,
            request.Description,
            request.IsReserved,
            !request.Floor.HasValue ? null : Floor.FromValue(request.Floor.Value),
            request.BedCount,
            request.Amount,
            request.Currency,
            request.Images);
        var update = roomRepository.UpdateAsync(room);

        Task.WaitAll([update], cancellationToken);

        return mapper.Map<RoomResult>(update.Result);
    }
}
