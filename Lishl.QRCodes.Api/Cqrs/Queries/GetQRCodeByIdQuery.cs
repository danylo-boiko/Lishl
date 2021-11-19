using System;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.QRCodes.Api.Cqrs.Queries
{
    public record GetQRCodeByIdQuery : IRequest<QRCode>
    {
        public Guid Id { get; set; }
    }
}