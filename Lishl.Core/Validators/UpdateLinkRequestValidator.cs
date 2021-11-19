using System.Collections.Generic;
using FluentValidation;
using Lishl.Core.Models;
using Lishl.Core.Requests;

namespace Lishl.Core.Validators
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
            RuleFor(link => link.Follows)
                .NotEmpty();
            RuleForEach(link => link.Follows)
                .SetValidator(new LinkFollowValidator());
        }
    }
}