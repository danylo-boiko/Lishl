using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Commands.Handlers
{
    public class UpdateLinkCommandHandler : IRequestHandler<UpdateLinkCommand, Link>
    {
        private readonly ILinksRepository _linksRepository;

        public UpdateLinkCommandHandler(ILinksRepository linksRepository)
        {
            _linksRepository = linksRepository;
        }

        public async Task<Link> Handle(UpdateLinkCommand request, CancellationToken cancellationToken)
        {
            var link = new Link
            {
                Id = request.Id,
                UserId = request.UserId,
                FullUrl = request.FullUrl,
                ShortUrl = request.ShortUrl,
                Follows = request.Follows
            };

            await _linksRepository.UpdateAsync(link);
            
            return await _linksRepository.GetAsync(link.Id);
        }
    }
}