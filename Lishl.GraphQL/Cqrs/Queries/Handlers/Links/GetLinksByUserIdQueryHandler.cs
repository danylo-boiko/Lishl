using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Services;
using Lishl.GraphQL.Cqrs.Queries.Links;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Handlers.Links
{
    public class GetLinksByUserIdQueryHandler : IRequestHandler<GetLinksByUserIdQuery, IEnumerable<Link>>
    {
        private readonly ILinksService _linksService;

        public GetLinksByUserIdQueryHandler(ILinksService linksService)
        {
            _linksService = linksService;
        }
        
        public async Task<IEnumerable<Link>> Handle(GetLinksByUserIdQuery query, CancellationToken cancellationToken)
        {
            return await _linksService.GetLinksByUserIdAsync(query.UserId);
        }
    }
}