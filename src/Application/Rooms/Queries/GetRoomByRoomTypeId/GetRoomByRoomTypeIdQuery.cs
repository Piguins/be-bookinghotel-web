using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Domain.RoomType.ValueObjects;

namespace Application.Rooms.Queries.GetRoomByRoomTypeId;
public record GetRoomByRoomTypeIdQuery(Guid RoomTypeId) : IQuery<RoomQueryResult>;
