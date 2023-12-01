using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.BookingManagement;

public record CreateBookingRequest(
    string UserId,
    string RoomTypeId,
    string FromDate,
    string ToDate,
    string RoomCount)
