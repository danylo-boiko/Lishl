using SkiaSharp;
using SkiaSharp.QrCode;

namespace Lishl.QRCodes.Api.QRCodeService
{
    public class QRCodeService : IQRCodeService
    {
        public byte[] ConvertUrlToByteArray(string url)
        {
            using (var generator = new QRCodeGenerator())
            {
                var qrCodeData = generator.CreateQrCode(url, ECCLevel.Q);
                var info = new SKImageInfo(256, 256);
                
                using (var surface = SKSurface.Create(info))
                {
                    var canvas = surface.Canvas;
                    canvas.Render(qrCodeData, info.Width, info.Height);
                    using (var image = surface.Snapshot())
                    using (var data = image.Encode(SKEncodedImageFormat.Png, 80))
                    {
                        return data.ToArray();
                    }
                }
            }
        }

        public SKBitmap ConvertByteArrayToSkBitmap(byte[] array)
        {
            return SKBitmap.Decode(array);
        }

        public bool SaveToPath(byte[] bitmap, string folderPath, string fileName)
        {
            using (var image = SKImage.FromBitmap(SKBitmap.Decode(bitmap)))
            using (var data = image.Encode(SKEncodedImageFormat.Png, 80))
            {
                using (var stream = File.OpenWrite(Path.Combine(folderPath, $"{fileName}.png")))
                {
                    data.SaveTo(stream);
                }
            }

            return true;
        }
    }
}