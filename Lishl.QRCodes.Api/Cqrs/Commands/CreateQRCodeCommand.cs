using System;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.QRCodes.Api.Cqrs.Commands
{
    public record CreateQRCodeCommand : IRequest<QRCode>
    {
        public Guid UserId { get; set; }
        public string Url { get; set; }
        public byte[] QRCodeBitmap { get; set; } 
    }
}