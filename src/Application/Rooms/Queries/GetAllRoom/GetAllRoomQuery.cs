using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Mediator;

namespace Application.Rooms.Queries.GetAllRoom;
public record GetAllRoomQuery() : IQuery<RoomQueryResult>;
