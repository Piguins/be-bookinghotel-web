﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using MediatR;

namespace Application.Bookings.BookingManagement.BookingManagementCommands.UpdateBooking;
public record UpdateBookingCommand(
    Guid UserId,
    Guid BookingId,
    Guid RoomTypeId,
    DateTime FromDate,
    DateTime ToDate,
    int RoomCount) : ICommand<BookingCommandResult>;