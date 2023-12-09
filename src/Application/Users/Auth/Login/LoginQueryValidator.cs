using FluentValidation;

namespace Application.Users.Auth.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage(DomainException.User.InvalidEmail.Message);
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(DomainException.User.InvalidPassword.Message);
    }
}
