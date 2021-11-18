using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Queries.Handlers
{
    public class GetLinkByShortUrlQueryHandler:  IRequestHandler<GetLinkByShortUrlQuery, Link>
    {
        private readonly ILinksRepository _linksRepository;

        public GetLinkByShortUrlQueryHandler(ILinksRepository linksRepository)
        {
            _linksRepository = linksRepository;
        }
        
        public async Task<Link> Handle(GetLinkByShortUrlQuery request, CancellationToken cancellationToken)
        {
            return await _linksRepository.GetByShortUrlAsync(request.ShortUrl);
        }
    }
}