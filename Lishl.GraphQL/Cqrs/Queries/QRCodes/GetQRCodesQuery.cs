using System.Collections.Generic;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.QRCodes
{
    public record GetQRCodesQuery : IRequest<IEnumerable<QRCode>>;
}