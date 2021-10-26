using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Handlers
{
    public class GetLinksByUserIdQueryHandler : IRequestHandler<GetLinksByUserIdQuery, IEnumerable<Link>>
    {
        private readonly ILinksService _linksService;

        public GetLinksByUserIdQueryHandler(ILinksService linksService)
        {
            _linksService = linksService;
        }
        
        public async Task<IEnumerable<Link>> Handle(GetLinksByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _linksService.GetLinksByUserId(request.UserId);
        }
    }
}