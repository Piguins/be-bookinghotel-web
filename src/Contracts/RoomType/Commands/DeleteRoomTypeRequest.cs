using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RoomType.Commands;
public record DeleteRoomTypeRequest(Guid RoomTypeId);
