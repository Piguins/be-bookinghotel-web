using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.Abstractions.Mediator;

namespace Application.Rooms.Commands.DeleteRoom;
public record DeleteRoomCommand(
    Guid RoomId) : ICommand<RoomCommandResult>;
