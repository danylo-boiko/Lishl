using System;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries
{
    public record GetQRCodeByIdQuery : IRequest<QRCode>
    {
        public Guid QRCodeId { get; set; } 
    }
}