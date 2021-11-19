using System;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands
{
    public record DeleteQRCodeCommand : IRequest<Guid>
    {
        public Guid QRCodeId { get; set; }
    }
}