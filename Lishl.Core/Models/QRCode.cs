using System;
using System.Drawing;

namespace Lishl.Core.Models
{
    public class QRCode : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Url { get; set; }
        public byte[]  QRCodeBitmap { get; set; } 
    }
}