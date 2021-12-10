using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.QRCodes.Api.Cqrs.Queries.Handlers
{
    public class GetQRCodesByUserIdQueryHandler : IRequestHandler<GetQRCodesByUserIdQuery, IEnumerable<QRCode>>
    {
        private readonly IQRCodesRepository _qrCodesRepository;

        public GetQRCodesByUserIdQueryHandler(IQRCodesRepository qrCodesRepository)
        {
            _qrCodesRepository = qrCodesRepository;
        }

        public async Task<IEnumerable<QRCode>> Handle(GetQRCodesByUserIdQuery query, CancellationToken cancellationToken)
        {
            return await _qrCodesRepository.GetAsync(l => l.UserId.Equals(query.UserId), query.PaginationFilter);
        }
    }
}