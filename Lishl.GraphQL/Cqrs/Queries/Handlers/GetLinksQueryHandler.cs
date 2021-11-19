using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Handlers
{
    public class GetLinksQueryHandler : IRequestHandler<GetLinksQuery, IEnumerable<Link>>
    {
        private readonly ILinksService _linksService;

        public GetLinksQueryHandler(ILinksService linksService)
        {
            _linksService = linksService;
        }
        
        public async Task<IEnumerable<Link>> Handle(GetLinksQuery query, CancellationToken cancellationToken)
        {
            return await _linksService.GetAsync();
        }
    }
}