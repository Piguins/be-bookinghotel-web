using FluentValidation;

namespace Application.RoomTypes.Commands.DeleteRoomType;
internal class DeleteRoomTypeCommandValidator : AbstractValidator<DeleteRoomTypeCommand>
{
    public DeleteRoomTypeCommandValidator()
    {
        RuleFor(x => x.RoomTypeId).NotEmpty();
    }
}
