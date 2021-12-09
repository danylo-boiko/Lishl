using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Core.Models;
using Lishl.Core.Requests.Link;
using Lishl.Core.Services;
using Lishl.GraphQL.Cqrs.Commands.Links;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers.Links
{
    public class UpdateLinkCommandHandler : IRequestHandler<UpdateLinkCommand, Link>
    {
        private readonly ILinksService _linksService; 
        private readonly IMapper _mapper;

        public UpdateLinkCommandHandler(ILinksService linksService, IMapper mapper)
        {
            _linksService = linksService;
            _mapper = mapper;
        }
        
        public async Task<Link> Handle(UpdateLinkCommand command, CancellationToken cancellationToken)
        {
            var updateLinkRequest = _mapper.Map<UpdateLinkRequest>(command);
            
            return await _linksService.UpdateAsync(command.Id, updateLinkRequest);
        }
    }
}