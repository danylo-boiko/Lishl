using FluentValidation;
using Lishl.Core.Requests.Link;

namespace Lishl.Core.Validators.Link
{
    public class CreateLinkRequestValidator : AbstractValidator<CreateLinkRequest>
    {
        public CreateLinkRequestValidator()
        {
            RuleFor(link => link.UserId)
                .NotNull()
                .NotEmpty();
            RuleFor(link => link.FullUrl)
                .NotNull()
                .NotEmpty();
        }
    }
}