using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Room;
public record RoomResponse(
    Guid RoomId,
    Guid RoomTypeId,
    bool IsReserved,
    string Name);

public record RoomList(List<RoomResponse> RoomResponses);
