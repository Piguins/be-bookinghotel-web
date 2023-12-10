using FluentValidation;

namespace Application.Rooms.Commands.CreateRoom;

public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomCommandValidator()
    {
        RuleFor(x => x.RoomTypeId)
            .NotEmpty();
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
