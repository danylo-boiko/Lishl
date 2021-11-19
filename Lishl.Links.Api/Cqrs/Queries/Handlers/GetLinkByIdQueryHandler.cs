using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Queries.Handlers
{
    public class GetLinkByIdQueryHandler : IRequestHandler<GetLinkByIdQuery, Link>
    {
        private readonly ILinksRepository _linksRepository;

        public GetLinkByIdQueryHandler(ILinksRepository linksRepository)
        {
            _linksRepository = linksRepository;
        }
        
        public async Task<Link> Handle(GetLinkByIdQuery query, CancellationToken cancellationToken)
        {
            return await _linksRepository.GetAsync(query.Id); 
        }
    }
}