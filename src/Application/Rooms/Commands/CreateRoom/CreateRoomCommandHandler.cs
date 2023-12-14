using Domain.Common.Enums;
using Domain.Common.ValueObjects;
using Domain.Room;

namespace Application.Rooms.Commands.CreateRoom;
internal sealed class CreateRoomCommandHandler(IRoomRepository roomRepository) : ICommandHandler<CreateRoomCommand, RoomCommandResult>
{
    public Task<Result<RoomCommandResult>> Handle(
        CreateRoomCommand request,
        CancellationToken cancellationToken)
    {
        if (Floor.FromValue(request.Floor) is not { } floor)
        {
            return Task.FromResult(Result.Failure<RoomCommandResult>(DomainException.Room.InvalidFloor));
        }
        if (Money.FromCurrency(request.Currency) is not { } price)
        {
            return Task.FromResult(Result.Failure<RoomCommandResult>(DomainException.InvalidCurrency));
        }

        price.Add(request.Amount);
        var room = Room.Create(
            request.Name,
            false,
            floor,
            request.BedCount,
            price);

        var add = roomRepository.AddAsync(room);

        Task.WaitAll([add], cancellationToken);

        return Task.FromResult<Result<RoomCommandResult>>(new RoomCommandResult(add.Result));
    }
}
