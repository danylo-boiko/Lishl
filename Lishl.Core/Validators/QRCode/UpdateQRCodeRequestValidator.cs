using FluentValidation;
using Lishl.Core.Requests.QRCode;

namespace Lishl.Core.Validators.QRCode
{
    public class UpdateQRCodeRequestValidator : AbstractValidator<UpdateQRCodeRequest>
    {
        public UpdateQRCodeRequestValidator()
        {
            Include(new CreateQRCodeRequestValidator());
        }
    }
}