using FluentValidation;
using Lishl.Core.Requests;

namespace Lishl.Core.Validators
{
    public class UpdateQRCodeRequestValidator : AbstractValidator<UpdateQRCodeRequest>
    {
        public UpdateQRCodeRequestValidator()
        {
            Include(new CreateQRCodeRequestValidator());
        }
    }
}