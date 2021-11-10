using FluentValidation;
using Lishl.Core.Models;

namespace Lishl.Core.Validators
{
    public class LinkFollowValidator : AbstractValidator<LinkFollow>
    {
        public LinkFollowValidator()
        {
            RuleFor(linkFollow => linkFollow.Date).NotEmpty();
            RuleFor(linkFollow => linkFollow.IpAddress).NotEmpty();
        }
    }
}