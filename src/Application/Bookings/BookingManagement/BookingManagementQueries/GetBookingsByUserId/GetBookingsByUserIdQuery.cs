using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;

namespace Application.Bookings.BookingManagement.BookingManagementQueries.GetAllBooking;
public record GetBookingsByUserIdQuery(Guid UserId) : IQuery<BookingQueryResult>;

