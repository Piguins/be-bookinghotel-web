using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.Abstractions.Mediator;
using Domain.Common.ValueObjects;

namespace Application.RoomTypes.Commands.DeleteRoomType;
public record DeleteRoomTypeCommand(
    Guid RoomTypeId) : ICommand<RoomTypeCommandResult>;

