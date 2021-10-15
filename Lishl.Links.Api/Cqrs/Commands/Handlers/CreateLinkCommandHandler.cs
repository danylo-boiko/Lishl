using System;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Commands.Handlers
{
    public class CreateLinkCommandHandler : IRequestHandler<CreateLinkCommand, Link>
    {
        private readonly ILinksRepository _linksRepository;

        public CreateLinkCommandHandler(ILinksRepository linksRepository)
        {
            _linksRepository = linksRepository;
        }
        
        public async Task<Link> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
        {
            var link = new Link
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                FullUrl = request.FullUrl,
                ShortUrl = request.ShortUrl
            };

            await _linksRepository.CreateAsync(link);
            
            return await _linksRepository.GetAsync(link.Id);
        }
    }
}