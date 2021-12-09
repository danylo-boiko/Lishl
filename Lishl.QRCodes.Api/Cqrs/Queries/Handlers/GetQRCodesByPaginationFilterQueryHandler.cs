using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.QRCodes.Api.Cqrs.Queries.Handlers
{
    public class GetQRCodesByPaginationFilterQueryHandler : IRequestHandler<GetQRCodesByPaginationFilterQuery, IEnumerable<QRCode>>
    {
        private readonly IQRCodesRepository _qrCodesRepository;

        public GetQRCodesByPaginationFilterQueryHandler(IQRCodesRepository qrCodesRepository)
        {
            _qrCodesRepository = qrCodesRepository;
        }
        
        public async Task<IEnumerable<QRCode>> Handle(GetQRCodesByPaginationFilterQuery query, CancellationToken cancellationToken)
        {
            return await _qrCodesRepository.GetAsync(query.PaginationFilter);
        }
    }
}