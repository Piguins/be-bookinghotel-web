namespace Application.Bookings.Queries.GetBookingsByUserId;

public record GetBookingsByUserIdQuery(string UserId) : IQuery<List<BookingResult>>;
