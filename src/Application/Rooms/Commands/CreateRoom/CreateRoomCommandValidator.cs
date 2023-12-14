using Domain.Common.ValueObjects;
using FluentValidation;

namespace Application.Rooms.Commands.CreateRoom;

public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
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
