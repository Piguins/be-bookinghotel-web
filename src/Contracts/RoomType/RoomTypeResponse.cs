using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.RoomType.Commands;

namespace Contracts.RoomType;
public record RoomTypeResponse(
    Guid RoomTypeId,
    string Floor,
    int BedCount,
    decimal Amount,
    string Currency);

public record RoomTypeList(List<RoomTypeResponse> RoomTypeResponses);
