using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Handlers
{
    public class GetLinksByUserIdQueryHandler : IRequestHandler<GetLinksByUserIdQuery, IEnumerable<Link>>
    {
        public Task<IEnumerable<Link>> Handle(GetLinksByUserIdQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}