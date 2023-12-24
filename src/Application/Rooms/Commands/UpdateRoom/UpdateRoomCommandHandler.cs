using Application.Abstractions.Persistence;
using Domain.Common.Enums;
using Domain.Rooms.ValueObjects;

namespace Application.Rooms.Commands.UpdateRoom;
internal sealed class UpdateRoomCommandHandler(
    IRoomRepository roomRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : ICommandHandler<UpdateRoomCommand, RoomResult>
{
    public async Task<Result<RoomResult>> Handle(
        UpdateRoomCommand request,
        CancellationToken cancellationToken)
    {
        if (await roomRepository.GetByIdAsync(RoomId.Create(request.RoomId), cancellationToken) is not { } room)
        {
            return Result.Failure<RoomResult>(DomainException.Room.RoomNotFound);
        }
        Floor? floor = null;
        if (request.Floor.HasValue)
        {
            if (await roomRepository.GetFloorByIdAsync(request.Floor.Value) is not { } value)
            {
                return Result.Failure<RoomResult>(DomainException.Room.InvalidFloor);
            }
            floor = value;
        }

        room.Update(
            request.Name,
            request.Description,
            request.IsReserved,
            request.Floor.HasValue ? floor : null,
            request.BedCount,
            request.Amount,
            request.Currency,
            request.Images);

        var update = roomRepository.Update(room);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<RoomResult>(update);
    }
}
