using AutoMapper;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using Lishl.QRCodes.Api.QRCodeService;
using MediatR;

namespace Lishl.QRCodes.Api.Cqrs.Commands.Handlers
{
    public class UpdateQRCodeCommandHandler : IRequestHandler<UpdateQRCodeCommand, QRCode>
    {
        private readonly IQRCodesRepository _qrCodesRepository;
        private readonly IQRCodeService _qrCodeService;
        private readonly IMapper _mapper;

        public UpdateQRCodeCommandHandler(IQRCodesRepository qrCodesRepository, IQRCodeService qrCodeService, IMapper mapper)
        {
            _qrCodesRepository = qrCodesRepository;
            _qrCodeService = qrCodeService;
            _mapper = mapper;
        }

        public async Task<QRCode> Handle(UpdateQRCodeCommand command, CancellationToken cancellationToken)
        {
            var qrCode = _mapper.Map<QRCode>(command);

            qrCode.QRCodeBitmap = _qrCodeService.ConvertUrlToByteArray(qrCode.Url);
            
            await _qrCodesRepository.UpdateAsync(qrCode);
            
            return await _qrCodesRepository.GetAsync(qrCode.Id);
        }
    }
}