using FluentValidation;
using Lishl.Core.Requests;

namespace Lishl.Core.Validators
{
    public class CreateQRCodeRequestValidator : AbstractValidator<CreateQRCodeRequest>
    {
        public CreateQRCodeRequestValidator()
        {
            RuleFor(QRCode => QRCode.UserId)
                .NotNull()
                .NotEmpty();
            RuleFor(QRCode => QRCode.Url)
                .NotNull()
                .NotEmpty();
        }
    }
}