using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Commands.Handlers
{
    public class UpdateLinkCommandHandler : IRequestHandler<UpdateLinkCommand, Link>
    {
        private readonly ILinksRepository _linksRepository;
        private readonly IMapper _mapper;

        public UpdateLinkCommandHandler(ILinksRepository linksRepository, IMapper mapper)
        {
            _linksRepository = linksRepository;
            _mapper = mapper;
        }

        public async Task<Link> Handle(UpdateLinkCommand command, CancellationToken cancellationToken)
        {
            var link = _mapper.Map<Link>(command);

            await _linksRepository.UpdateAsync(link);
            
            return await _linksRepository.GetAsync(link.Id);
        }
    }
}