using FluentValidation;

namespace Application.Users.Auth.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage(DomainException.User.InvalidEmail.Message);
        RuleFor(x => x.FirstName)
            .NotEmpty();
        RuleFor(x => x.LastName)
            .NotEmpty();
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(DomainException.User.InvalidPassword.Message);
    }
}
