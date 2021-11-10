using FluentValidation;
using Lishl.Core.Requests;

namespace Lishl.Core.Validators
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            Include(new CreateUserRequestValidator());
        }
    }
}