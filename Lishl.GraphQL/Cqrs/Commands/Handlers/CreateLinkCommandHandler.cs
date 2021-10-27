using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.GraphQL.Requests;
using Lishl.Core.Models;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers
{
    public class CreateLinkCommandHandler : IRequestHandler<CreateLinkCommand, Link>
    {
        private readonly ILinksService _linksService; 
        
        public CreateLinkCommandHandler(ILinksService linksService)
        {
            _linksService = linksService;
        }
        
        public async Task<Link> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
        {
            return await _linksService.CreateAsync(new CreateLinkRequest
            {
                UserId = request.UserId,
                FullUrl = request.FullUrl,
                ShortUrl = request.ShortUrl
            });
        }
    }
}