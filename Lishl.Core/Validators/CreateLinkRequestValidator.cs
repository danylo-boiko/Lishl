using FluentValidation;
using Lishl.Core.Requests;

namespace Lishl.Core.Validators
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
            RuleFor(link => link.ShortUrl)
                .NotNull()
                .NotEmpty();
        }
    }
}