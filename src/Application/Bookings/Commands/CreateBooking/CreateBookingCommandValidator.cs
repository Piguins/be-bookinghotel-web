using FluentValidation;

namespace Application.Bookings.Commands.CreateBooking;

public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();
        RuleFor(x => x.OrderId)
            .NotEmpty();
        RuleFor(x => x.FromDate)
            .NotEmpty();
        RuleFor(x => x.ToDate)
            .NotEmpty();
        RuleFor(x => x.Floor)
            .GreaterThan(0)
            .LessThan(5);
        RuleFor(x => x.BedCount)
            .GreaterThan(0);
    }
}
