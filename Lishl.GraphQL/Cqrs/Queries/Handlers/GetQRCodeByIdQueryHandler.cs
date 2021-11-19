using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Handlers
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