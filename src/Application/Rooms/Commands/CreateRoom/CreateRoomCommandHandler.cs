using Domain.Common.Enums;
using Domain.Common.ValueObjects;
using Domain.Room;

namespace Application.Rooms.Commands.CreateRoom;
internal sealed class CreateRoomCommandHandler(
    IRoomRepository roomRepository,
    IMapper mapper) : ICommandHandler<CreateRoomCommand, RoomResult>
{
    public Task<Result<RoomResult>> Handle(
        CreateRoomCommand request,
        CancellationToken cancellationToken)
    {
        if (Floor.FromValue(request.Floor) is not { } floor)
        {
            return Task.FromResult(Result.Failure<RoomResult>(DomainException.Room.InvalidFloor));
        }
        if (Money.FromCurrency(request.Currency) is not { } price)
        {
            return Task.FromResult(Result.Failure<RoomResult>(DomainException.InvalidCurrency));
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

        var add = roomRepository.AddAsync(room);

        Task.WaitAll([add], cancellationToken);

        return Task.FromResult<Result<RoomResult>>(mapper.Map<RoomResult>(add.Result));
    }
}
