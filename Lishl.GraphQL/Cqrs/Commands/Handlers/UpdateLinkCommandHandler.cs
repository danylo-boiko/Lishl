using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Requests;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers
{
    public class UpdateLinkCommandHandler : IRequestHandler<UpdateLinkCommand, Link>
    {
        private readonly ILinksService _linksService; 
        
        public UpdateLinkCommandHandler(ILinksService linksService)
        {
            _linksService = linksService;
        }
        
        public async Task<Link> Handle(UpdateLinkCommand request, CancellationToken cancellationToken)
        {
            return await _linksService.UpdateAsync(request.Id, new UpdateLinkRequest
            {
                UserId = request.UserId,
                FullUrl = request.FullUrl,
                ShortUrl = request.ShortUrl,
                Follows = request.Follows
            });
        }
    }
}