using FluentValidation;
using Lishl.Core.Requests.QRCode;

namespace Lishl.Core.Validators.QRCode
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