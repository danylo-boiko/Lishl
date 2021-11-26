using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using QRCoder;

namespace Lishl.QRCodes.Api.Managers
{
    public static class QRCodeHelper
    {
        public static byte[] GetUrlBitmap(string url)
        {
            var qrCodeGenerator = new QRCodeGenerator();
            var qrCodeData = qrCodeGenerator.CreateQrCode(url,QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            return BitmapToBytesCode(qrCode.GetGraphic(20));
        }
        
        private static byte[] BitmapToBytesCode(Bitmap image)
        {
            using var stream = new MemoryStream();
            image.Save(stream, ImageFormat.Png);      
            return stream.ToArray();
        }
    }
}