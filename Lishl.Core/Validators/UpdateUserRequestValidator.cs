using FluentValidation;
using Lishl.Core.Requests;

namespace Lishl.Core.Validators
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(user => user.Username)
                .Length(min: 3, max: 32)
                .Matches("^[A-Za-z0-9_-]+$").WithMessage("Only letters, numbers, dashes and underscores.");
            RuleFor(user => user.Email)
                .EmailAddress();
            RuleForEach(registerRequest => registerRequest.Roles)
                .IsInEnum();
            RuleFor(user => user.Password)
                .Length(min: 8, max: 100)
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage("Password must contains at least one letter and one number.");
        }
    }
}