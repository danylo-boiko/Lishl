using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Core.Repositories;
using MediatR;
using QRCoder;
using QRCodeModel = Lishl.Core.Models.QRCode;

namespace Lishl.QRCodes.Api.Cqrs.Commands.Handlers
{
    public class UpdateQRCodeCommandHandler : IRequestHandler<UpdateQRCodeCommand, QRCodeModel>
    {
        private readonly IQRCodesRepository _qrCodesRepository;
        private readonly IMapper _mapper;

        public UpdateQRCodeCommandHandler(IQRCodesRepository qrCodesRepository, IMapper mapper)
        {
            _qrCodesRepository = qrCodesRepository;
            _mapper = mapper;
        }

        public async Task<QRCodeModel> Handle(UpdateQRCodeCommand command, CancellationToken cancellationToken)
        {
            var qrCodeModel = _mapper.Map<QRCodeModel>(command);

            var qrCodeGenerator = new QRCodeGenerator();
            var qrCodeData = qrCodeGenerator.CreateQrCode(qrCodeModel.Url,QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            
            qrCodeModel.QRCodeBitmap = BitmapToBytesCode(qrCode.GetGraphic(20));
            
            await _qrCodesRepository.UpdateAsync(qrCodeModel);
            
            return await _qrCodesRepository.GetAsync(qrCodeModel.Id);
        }
        
        private static byte[] BitmapToBytesCode(Bitmap image)
        {
            using var stream = new MemoryStream();
            image.Save(stream, ImageFormat.Png);      
            return stream.ToArray();
        }
    }
}