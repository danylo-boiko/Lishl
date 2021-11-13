using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Commands.Handlers
{
    public class CreateLinkCommandHandler : IRequestHandler<CreateLinkCommand, Link>
    {
        private readonly ILinksRepository _linksRepository;
        private readonly IMapper _mapper;

        public CreateLinkCommandHandler(ILinksRepository linksRepository, IMapper mapper)
        {
            _linksRepository = linksRepository;
            _mapper = mapper;
        }
        
        public async Task<Link> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
        {
            var link = _mapper.Map<Link>(request);

            await _linksRepository.CreateAsync(link);
            
            return await _linksRepository.GetAsync(link.Id);
        }
    }
}