using System;
using System.Collections.Generic;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.QRCodes
{
    public record GetQRCodesByUserIdQuery : IRequest<IEnumerable<QRCode>>
    {
        public Guid UserId { get; set; }
    }
}