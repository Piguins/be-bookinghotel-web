using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.RoomTypes.Commands.DeleteRoomType;
using FluentValidation;

namespace Application.RoomTypes.Commands.DeleteRoomType;
internal class DeleteRoomTypeCommandValidator : AbstractValidator<DeleteRoomTypeCommand>
{
    public DeleteRoomTypeCommandValidator()
    {
        RuleFor(x => x.RoomTypeId).NotEmpty();
    }
}
