using FluentValidation;
using Lishl.Core.Requests.Link;
using Lishl.Core.Validators.LinkFollow;

namespace Lishl.Core.Validators.Link
{
    public class UpdateLinkRequestValidator : AbstractValidator<UpdateLinkRequest>
    {
        public UpdateLinkRequestValidator()
        {
            RuleFor(link => link.UserId)
                .NotEmpty();
            RuleFor(link => link.FullUrl)
                .NotEmpty();
            RuleFor(link => link.ShortUrl)
                .NotEmpty();
            RuleForEach(link => link.Follows)
                .SetValidator(new LinkFollowValidator());
        }
    }
}