using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Core.Models;
using Lishl.Core.Requests.QRCode;
using Lishl.Core.Services;
using Lishl.GraphQL.Cqrs.Commands.QRCodes;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers.QRCodes
{
    public class CreateQRCodeCommandHandler : IRequestHandler<CreateQRCodeCommand, QRCode>
    {
        private readonly IQRCodesService _qrCodesService;
        private readonly IMapper _mapper;

        public CreateQRCodeCommandHandler(IQRCodesService qrCodesService, IMapper mapper)
        {
            _qrCodesService = qrCodesService;
            _mapper = mapper;
        }
        
        public async Task<QRCode> Handle(CreateQRCodeCommand command, CancellationToken cancellationToken)
        {
            var createQRCodeRequest = _mapper.Map<CreateQRCodeRequest>(command);
            
            return await _qrCodesService.CreateAsync(createQRCodeRequest);
        }
    }
}