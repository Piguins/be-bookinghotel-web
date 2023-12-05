﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Application.Bookings.BookingManagement;
using MediatR;

namespace Application.Bookings.BookingManagement.CreateBooking;
public record ConfirmBookingCommand(
    Guid BookingId,
    Guid UserId) : ICommand<BookingResult>;
