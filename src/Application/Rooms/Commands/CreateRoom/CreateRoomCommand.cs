using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.Abstractions.Mediator;

namespace Application.Rooms.Commands.CreateRoom;
public record CreateRoomCommand(
    Guid RoomTypeId,
    string Name,
    bool IsReserved) : ICommand<RoomCommandResult>;
