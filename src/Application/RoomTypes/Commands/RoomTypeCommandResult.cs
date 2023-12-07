using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.RoomType;

namespace Application.RoomTypes.Commands;
public record RoomTypeCommandResult(
    RoomType RoomType);
