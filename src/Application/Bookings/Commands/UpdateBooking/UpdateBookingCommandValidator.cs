using FluentValidation;

namespace Application.Bookings.Commands.UpdateBooking;

public class UpdateBookingCommandValidator : AbstractValidator<UpdateBookingCommand>
{
    public UpdateBookingCommandValidator()
    {
        RuleFor(x => x.BookingId)
            .NotEmpty();
        // RuleFor(x => x.FromDate)
        //     .NotEmpty();
        // RuleFor(x => x.ToDate)
        //     .NotEmpty();
        RuleFor(x => x.Floor)
            .GreaterThan(0)
            .LessThan(5);
        RuleFor(x => x.BedCount)
            .GreaterThan(0);
    }
}
