using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RoomType.Commands;
public record CreateRoomTypeRequest(
    int Floor,
    int BedCount,
    decimal Amount,
    string Currency);
