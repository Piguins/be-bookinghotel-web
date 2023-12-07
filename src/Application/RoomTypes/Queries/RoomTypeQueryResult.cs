using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Booking;
using Domain.RoomType;

namespace Application.RoomTypes.Queries;
public record RoomTypeQueryResult(
    List<RoomType> RoomTypes);
