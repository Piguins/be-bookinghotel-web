using Domain.Common.ValueObjects;
using FluentValidation;

namespace Application.Rooms.Commands.UpdateRoom;

public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
{
    public UpdateRoomCommandValidator()
    {
        RuleFor(x => x.RoomId)
            .NotEmpty();
        // RuleFor(x => x.IsReserved)
        //     .NotEmpty();
        // RuleFor(x => x.Name)
        //     .NotEmpty();
        RuleFor(x => x.BedCount)
            .GreaterThan(0);
        RuleFor(x => x.Currency)
            .Matches($"^{Money.Usd.Currency}|{Money.Vnd.Currency}$")
            .WithMessage("Currency must be USD or VND");
        RuleFor(x => x.Amount)
            .GreaterThan(0);
        RuleFor(x => x.Floor)
            .GreaterThan(-2)
            .LessThan(3);
    }
}
