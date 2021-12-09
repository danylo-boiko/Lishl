using FluentValidation;
using Lishl.Core.Requests.User;

namespace Lishl.Core.Validators.User
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty()
                .Length(min: 3, max: 32)
                .Matches("^[A-Za-z0-9_-]+$").WithMessage("Only letters, numbers, dashes and underscores.");
            RuleFor(user => user.Email)
                .NotEmpty()
                .EmailAddress();
            RuleForEach(registerRequest => registerRequest.Roles)
                .IsInEnum();
            RuleFor(user => user.Password)
                .NotEmpty()
                .Length(min: 8, max: 100)
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage("Password must contains at least one letter and one number.");
        }
    }
}