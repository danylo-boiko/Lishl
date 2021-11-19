using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Handlers
{
    public class GetQRCodesQueryHandler : IRequestHandler<GetQRCodesQuery, IEnumerable<QRCode>>
    {
        private readonly IQRCodesService _qrCodesService;

        public GetQRCodesQueryHandler(IQRCodesService qrCodesService)
        {
            _qrCodesService = qrCodesService;
        }
        
        public async Task<IEnumerable<QRCode>> Handle(GetQRCodesQuery query, CancellationToken cancellationToken)
        {
            return await _qrCodesService.GetAsync();
        }
    }
}