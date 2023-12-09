using FluentValidation;

namespace Application.Bookings.Commands.CreateBooking;

public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingCommandValidator()
    {
        RuleFor(x => x.UserId)
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
