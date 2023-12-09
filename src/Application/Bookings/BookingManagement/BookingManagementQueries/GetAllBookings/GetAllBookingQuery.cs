﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;

namespace Application.Bookings.BookingManagement.BookingManagementQueries.GetAllBookings;
public record GetAllBookingQuery : IQuery<BookingQueryResult>
{
}
