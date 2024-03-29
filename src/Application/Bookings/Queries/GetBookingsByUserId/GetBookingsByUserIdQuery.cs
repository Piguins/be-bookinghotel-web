﻿namespace Application.Bookings.Queries.GetBookingsByUserId;

public record GetBookingsByUserIdQuery(Guid UserId) : IQuery<List<BookingResult>>;
