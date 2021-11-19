using System;

namespace Lishl.QRCodes.Api.Responses
{
    public class QRCodeResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Url { get; set; }
        public byte[] QRCodeBitmap { get; set; } 
    }
}