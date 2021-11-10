using FluentValidation;
using Lishl.Core.Requests;

namespace Lishl.Core.Validators
{
    public class UpdateLinkRequestValidator : AbstractValidator<UpdateLinkRequest>
    {
        public UpdateLinkRequestValidator()
        {
            Include(new CreateLinkRequestValidator());
            RuleForEach(link => link.Follows).SetValidator(new LinkFollowValidator());
        }
    }
}