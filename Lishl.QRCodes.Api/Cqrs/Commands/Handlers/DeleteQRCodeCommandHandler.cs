using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.QRCodes.Api.Cqrs.Commands.Handlers
{
    public class DeleteQRCodeCommandHandler : AsyncRequestHandler<DeleteQRCodeCommand>
    {
        private readonly IQRCodesRepository _qrCodesRepository;

        public DeleteQRCodeCommandHandler(IQRCodesRepository qrCodesRepository)
        {
            _qrCodesRepository = qrCodesRepository;
        }
        
        protected override async Task Handle(DeleteQRCodeCommand command, CancellationToken cancellationToken)
        {
            await _qrCodesRepository.DeleteAsync(command.Id);
        }
    }
}