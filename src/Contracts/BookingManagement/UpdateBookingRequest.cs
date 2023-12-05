using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.BookingManagement;
public record UpdateBookingRequest(
    Guid UserId,
    Guid BookingId,
    Guid RoomTypeId,
    DateTime FromDate,
    DateTime ToDate,
    int RoomCount);
