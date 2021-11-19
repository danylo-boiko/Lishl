using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Handlers
{
    public class GetQRCodesByUserIdQueryHandler : IRequestHandler<GetQRCodesByUserIdQuery, IEnumerable<QRCode>>
    {
        private readonly IQRCodesService _qrCodesService;

        public GetQRCodesByUserIdQueryHandler(IQRCodesService qrCodesService)
        {
            _qrCodesService = qrCodesService;
        }
        
        public async Task<IEnumerable<QRCode>> Handle(GetQRCodesByUserIdQuery query, CancellationToken cancellationToken)
        {
            return await _qrCodesService.GetQRCodesByUserIdAsync(query.UserId);
        }
    }
}