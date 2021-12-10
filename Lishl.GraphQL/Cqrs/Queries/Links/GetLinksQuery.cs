using System.Collections.Generic;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Links
{
    public record GetLinksQuery : IRequest<IEnumerable<Link>>;
}