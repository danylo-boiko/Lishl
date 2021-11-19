using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Core.Models;
using Lishl.Core.Requests;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers
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