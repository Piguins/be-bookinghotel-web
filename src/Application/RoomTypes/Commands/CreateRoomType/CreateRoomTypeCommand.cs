﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.Abstractions.Messaging;
using Domain.Common.ValueObjects;

namespace Application.RoomTypes.Commands.CreateRoomType;
public record CreateRoomTypeCommand(
    int Floor,
    int BedCount,
    decimal Amount,
    int Currency) : ICommand<RoomTypeCommandResult>;

