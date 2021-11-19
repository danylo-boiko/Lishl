using System;
using System.Collections.Generic;
using Lishl.Core;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.QRCodes.Api.Cqrs.Queries
{
    public record GetQRCodesByUserIdQuery : IRequest<IEnumerable<QRCode>>
    {
        public Guid UserId { get; set; }
        public PaginationFilter PaginationFilter { get; set; }
    }
}