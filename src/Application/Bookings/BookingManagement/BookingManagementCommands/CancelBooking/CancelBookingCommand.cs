using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using MediatR;

namespace Application.Bookings.BookingManagement.BookingManagementCommands.CancelBooking;
public record CancelBookingCommand(
    Guid BookingId,
    Guid UserId) : ICommand<BookingCommandResult>;
