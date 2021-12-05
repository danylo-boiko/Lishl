using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using Lishl.QRCodes.Api.Helpers;
using MediatR;


namespace Lishl.QRCodes.Api.Cqrs.Commands.Handlers
{
    public class CreateQRCodeCommandHandler : IRequestHandler<CreateQRCodeCommand, QRCode>
    {
        private readonly IQRCodesRepository _qrCodesRepository;
        private readonly IMapper _mapper;

        public CreateQRCodeCommandHandler(IQRCodesRepository qrCodesRepository, IMapper mapper)
        {
            _qrCodesRepository = qrCodesRepository;
            _mapper = mapper;
        }

        public async Task<QRCode> Handle(CreateQRCodeCommand command, CancellationToken cancellationToken)
        {
            var qrCode = _mapper.Map<QRCode>(command);

            qrCode.QRCodeBitmap = QRCodeHelper.GetUrlBitmap(qrCode.Url);

            return await _qrCodesRepository.CreateAsync(qrCode);
        }
    }
}