using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Services;
using Lishl.GraphQL.Cqrs.Queries.QRCodes;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Handlers.QRCodes
{
    public class GetQRCodeByIdQueryHandler : IRequestHandler<GetQRCodeByIdQuery, QRCode>
    {
        private readonly IQRCodesService _qrCodesService;

        public GetQRCodeByIdQueryHandler(IQRCodesService qrCodesService)
        {
            _qrCodesService = qrCodesService;
        }
        
        public async Task<QRCode> Handle(GetQRCodeByIdQuery query, CancellationToken cancellationToken)
        {
            return await _qrCodesService.GetAsync(query.QRCodeId);
        }
    }
}