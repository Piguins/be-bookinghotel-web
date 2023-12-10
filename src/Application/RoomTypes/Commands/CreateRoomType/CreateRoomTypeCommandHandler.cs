using Domain.Common.ValueObjects;
using Domain.RoomType;
using Domain.RoomType.Enums;

namespace Application.RoomTypes.Commands.CreateRoomType;
internal sealed class CreateRoomTypeCommandHandler(IRoomTypeRepository roomTypeRepository) : ICommandHandler<CreateRoomTypeCommand, RoomTypeCommandResult>
{
    public Task<Result<RoomTypeCommandResult>> Handle(
        CreateRoomTypeCommand request,
        CancellationToken cancellationToken)
    {
        if (Floor.FromValue(request.Floor) is not { } floor)
        {
            return Task.FromResult(Result.Failure<RoomTypeCommandResult>(DomainException.RoomType.InvalidFloor));
        }
        if (Money.FromCurrency(request.Currency) is not { } price)
        {
            return Task.FromResult(Result.Failure<RoomTypeCommandResult>(DomainException.InvalidCurrency));
        }

        price.Add(request.Amount);
        var roomType = RoomType.Create(floor, request.BedCount, price);

        var add = roomTypeRepository.AddAsync(roomType);

        Task.WaitAll([add],
                     cancellationToken);

        return Task.FromResult<Result<RoomTypeCommandResult>>(new RoomTypeCommandResult(add.Result));
    }
}
