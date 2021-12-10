using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.QRCodes.Api.Cqrs.Queries.Handlers
{
    public class GetQRCodeByIdQueryHandler : IRequestHandler<GetQRCodeByIdQuery, QRCode>
    {
        private readonly IQRCodesRepository _qrCodesRepository;

        public GetQRCodeByIdQueryHandler(IQRCodesRepository qrCodesRepository)
        {
            _qrCodesRepository = qrCodesRepository;
        }

        public async Task<QRCode> Handle(GetQRCodeByIdQuery query, CancellationToken cancellationToken)
        {
            return await _qrCodesRepository.GetAsync(query.Id); 
        }
    }
}