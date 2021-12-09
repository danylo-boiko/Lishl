using FluentValidation;
using Lishl.Core.Requests.Auth;

namespace Lishl.Core.Validators.Auth
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(user => user.Password)
                .NotEmpty()
                .Length(min: 8, max: 100)
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage("Password must contains at least one letter and one number.");
        }
    }
}