using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Handlers
{
    public class GetLinkByIdQueryHandler : IRequestHandler<GetLinkByIdQuery, Link>
    {
        public Task<Link> Handle(GetLinkByIdQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}