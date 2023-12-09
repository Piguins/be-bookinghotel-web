namespace Contracts.Booking;

public record BookingResponse(
    Guid Id,
    Guid UserId,
    Guid RoomTypeId,
    DateTime FromDate,
    DateTime ToDate,
    string BookingStatus,
    int RoomCount);

public record ListBookingResponse(List<BookingResponse> BookingResponses);
