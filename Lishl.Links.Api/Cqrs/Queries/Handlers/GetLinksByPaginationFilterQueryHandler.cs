using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Queries.Handlers
{
    public class GetLinksByPaginationFilterQueryHandler : IRequestHandler<GetLinksByPaginationFilterQuery, List<Link>>
    {
        private readonly ILinksRepository _linksRepository;

        public GetLinksByPaginationFilterQueryHandler(ILinksRepository linksRepository)
        {
            _linksRepository = linksRepository;
        }
        
        public async Task<List<Link>> Handle(GetLinksByPaginationFilterQuery request, CancellationToken cancellationToken)
        {
            return await _linksRepository.GetAsync(request.PaginationFilter);
        }
    }
}