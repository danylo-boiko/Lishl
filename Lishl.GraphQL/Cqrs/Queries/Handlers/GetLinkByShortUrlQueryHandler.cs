using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Handlers
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