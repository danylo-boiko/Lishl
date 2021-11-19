using System;
using MediatR;

namespace Lishl.QRCodes.Api.Cqrs.Commands
{
    public record DeleteQRCodeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}