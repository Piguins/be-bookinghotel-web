using Application.Abstractions.Persistence;
using Domain.Common.ValueObjects;
using Domain.Rooms;

namespace Application.Rooms.Commands.CreateRoom;
internal sealed class CreateRoomCommandHandler(
    IRoomRepository roomRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : ICommandHandler<CreateRoomCommand, RoomResult>
{
    public async Task<Result<RoomResult>> Handle(
        CreateRoomCommand request,
        CancellationToken cancellationToken)
    {
        if (await roomRepository.GetFloorByIdAsync(request.Floor) is not { } floor)
        {
            return Result.Failure<RoomResult>(DomainException.Room.InvalidFloor);
        }
        if (Money.FromCurrency(request.Currency) is not { } price)
        {
            return Result.Failure<RoomResult>(DomainException.InvalidCurrency);
        }

        price.Add(request.Amount);
        var room = Room.Create(
            request.Name,
            request.Description,
            false,
            floor,
            request.BedCount,
            price,
            request.Images);

        var add = roomRepository.Add(room);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<RoomResult>(add);
    }
}
