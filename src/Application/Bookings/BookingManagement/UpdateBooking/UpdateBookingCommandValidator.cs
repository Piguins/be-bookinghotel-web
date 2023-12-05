using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Bookings.BookingManagement.UpdateBooking;
public class UpdateBookingCommandValidator : AbstractValidator<UpdateBookingCommand>
{
    public UpdateBookingCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();
        RuleFor(x => x.BookingId)
            .NotEmpty();
        RuleFor(x => x.RoomTypeId)
            .NotEmpty();
        RuleFor(x => x.FromDate)
            .NotEmpty();
        RuleFor(x => x.ToDate)
            .NotEmpty();
        RuleFor(x => x.RoomCount)
            .GreaterThan(0);
    }
}
