using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Persistence;
using Domain.RoomType;
using Domain.RoomType.ValueObjects;

namespace Application.RoomTypes;
public interface IRoomTypeRepository : IRepository<RoomType,RoomTypeId>
{
}
