using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Handlers
{
    public class GetLinkByIdQueryHandler : IRequestHandler<GetLinkByIdQuery, Link>
    {
        private readonly ILinksService _linksService;

        public GetLinkByIdQueryHandler(ILinksService linksService)
        {
            _linksService = linksService;
        }
        
        public async Task<Link> Handle(GetLinkByIdQuery request, CancellationToken cancellationToken)
        {
            return await _linksService.GetAsync(request.LinkId);
        }
    }
}