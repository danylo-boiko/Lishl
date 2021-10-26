using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Queries.Handlers
{
    public class GetLinksByUserIdQueryHandler :  IRequestHandler<GetLinksByUserIdQuery, IEnumerable<Link>>
    {
        private readonly ILinksRepository _linksRepository;

        public GetLinksByUserIdQueryHandler(ILinksRepository linksRepository)
        {
            _linksRepository = linksRepository;
        }
        
        public async Task<IEnumerable<Link>> Handle(GetLinksByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _linksRepository.GetAsync(l => l.UserId == request.UserId, request.PaginationFilter);
        }
    }
}