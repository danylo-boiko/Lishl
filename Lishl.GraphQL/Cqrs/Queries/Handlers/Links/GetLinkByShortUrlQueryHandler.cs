using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Services;
using Lishl.GraphQL.Cqrs.Queries.Links;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Handlers.Links
{
    public class GetLinkByShortUrlQueryHandler : IRequestHandler<GetLinkByShortUrlQuery, Link>
    {
        private readonly ILinksService _linksService;

        public GetLinkByShortUrlQueryHandler(ILinksService linksService)
        {
            _linksService = linksService;
        }
        
        public async Task<Link> Handle(GetLinkByShortUrlQuery query, CancellationToken cancellationToken)
        {
            return await _linksService.GetAsync(query.ShortUrl);
        }
    }
}