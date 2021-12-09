using System;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Services;
using Lishl.GraphQL.Cqrs.Commands.QRCodes;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers.QRCodes
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