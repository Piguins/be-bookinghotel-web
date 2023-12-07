﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Room.Commands;
public record CreateRoomRequest(
    Guid RoomTypeId,
    bool IsReserved,
    string Name);
