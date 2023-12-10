using FluentValidation;

namespace Application.RoomTypes.Commands.CreateRoomType;

internal class CreateRoomTypeCommandValidator : AbstractValidator<CreateRoomTypeCommand>
{
    public CreateRoomTypeCommandValidator()
    {
        RuleFor(x => x.BedCount)
            .GreaterThan(0);
        RuleFor(x => x.Currency)
            .Length(3);
        RuleFor(x => x.Amount)
            .GreaterThan(0);
        RuleFor(x => x.Floor)
            .GreaterThan(-2)
            .LessThan(3);
    }
}
