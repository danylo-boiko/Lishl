using SkiaSharp;

namespace Lishl.QRCodes.Api.QRCodeService;

public interface IQRCodeService
{
    public byte[] ConvertUrlToByteArray(string url);
    public SKBitmap ConvertByteArrayToSkBitmap(byte[] bitmap);
    public bool SaveToPath(byte[] bitmap, string folderPath, string fileName);
}