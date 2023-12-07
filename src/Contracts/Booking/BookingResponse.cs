using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.BookingManagement;
public record BookingResponse(
    Guid BookingId,
    Guid UserId,
    Guid RoomTypeId,
    DateTime FromDate,
    DateTime ToDate,
    string Status,
    int RoomCount);

public record BookingList(List<BookingResponse> BookingResponses);
