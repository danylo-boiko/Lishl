using FluentValidation;

namespace Lishl.Core.Validators.LinkFollow
{
    public class LinkFollowValidator : AbstractValidator<Models.LinkFollow>
    {
        public LinkFollowValidator()
        {
            RuleFor(linkFollow => linkFollow.Date).NotEmpty();
            RuleFor(linkFollow => linkFollow.IpAddress).NotEmpty();
        }
    }
}