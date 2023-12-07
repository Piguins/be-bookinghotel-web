using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.Abstractions.Messaging;

namespace Application.Rooms.Commands.UpdateRoom;
public record UpdateRoomCommand(
    Guid RoomId,
    Guid RoomTypeId,
    string Name,
    bool IsReserved) : ICommand<RoomCommandResult>;
