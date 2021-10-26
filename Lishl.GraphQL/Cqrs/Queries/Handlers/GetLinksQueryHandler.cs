using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Handlers
{
    public class GetLinksQueryHandler : IRequestHandler<GetLinksQuery, IEnumerable<Link>>
    {
        public Task<IEnumerable<Link>> Handle(GetLinksQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}