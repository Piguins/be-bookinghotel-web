using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Rooms.Commands.CreateRoom;
using FluentValidation;

namespace Application.Rooms.Commands.UpdateRoom;
public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
{
    public UpdateRoomCommandValidator()
    {
        RuleFor(x => x.RoomId)
            .NotEmpty();
        RuleFor(x => x.IsReserved)
            .NotEmpty();
        RuleFor(x => x.Name)
            .NotEmpty();
        RuleFor(x => x.RoomTypeId)
            .NotEmpty();
    }
}
