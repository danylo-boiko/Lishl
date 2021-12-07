using FluentValidation;
using Lishl.Core.Requests;

namespace Lishl.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            Include(new LoginRequestValidator());
            
            RuleFor(user => user.Username)
                .NotEmpty()
                .Length(min: 3, max: 32)
                .Matches("^[A-Za-z0-9_-]+$").WithMessage("Only letters, numbers, dashes and underscores.");
        }
    }
}