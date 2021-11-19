using System;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers
{
    public class DeleteQRCodeCommandHandler : IRequestHandler<DeleteQRCodeCommand, Guid>
    {
        private readonly IQRCodesService _qrCodesService;

        public DeleteQRCodeCommandHandler(IQRCodesService qrCodesService)
        {
            _qrCodesService = qrCodesService;
        }

        public async Task<Guid> Handle(DeleteQRCodeCommand command, CancellationToken cancellationToken)
        {
            await _qrCodesService.DeleteAsync(command.QRCodeId);

            return command.QRCodeId;
        }
    }
}