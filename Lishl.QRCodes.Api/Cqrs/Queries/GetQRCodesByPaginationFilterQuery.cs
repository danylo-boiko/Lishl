using Lishl.Core;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.QRCodes.Api.Cqrs.Queries
{
    public record GetQRCodesByPaginationFilterQuery:  IRequest<IEnumerable<QRCode>>
    {
        public PaginationFilter PaginationFilter { get; set; }
    }
}