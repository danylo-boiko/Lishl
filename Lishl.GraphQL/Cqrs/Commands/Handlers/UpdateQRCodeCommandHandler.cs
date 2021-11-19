using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Core.Models;
using Lishl.Core.Requests;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers
{
    public class UpdateQRCodeCommandHandler : IRequestHandler<UpdateQRCodeCommand, QRCode>
    {
        private readonly IQRCodesService _qrCodesService;
        private readonly IMapper _mapper;

        public UpdateQRCodeCommandHandler(IQRCodesService qrCodesService, IMapper mapper)
        {
            _qrCodesService = qrCodesService;
            _mapper = mapper;
        }
        
        public async Task<QRCode> Handle(UpdateQRCodeCommand command, CancellationToken cancellationToken)
        {
            var updateQRCodeRequest = _mapper.Map<UpdateQRCodeRequest>(command);
            
            return await _qrCodesService.UpdateAsync(command.Id, updateQRCodeRequest);
        }
    }
}