using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Core.Models;
using Lishl.Core.Requests;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers
{
    public class CreateLinkCommandHandler : IRequestHandler<CreateLinkCommand, Link>
    {
        private readonly ILinksService _linksService; 
        private readonly IMapper _mapper;

        public CreateLinkCommandHandler(ILinksService linksService, IMapper mapper)
        {
            _linksService = linksService;
            _mapper = mapper;
        }
        
        public async Task<Link> Handle(CreateLinkCommand command, CancellationToken cancellationToken)
        {
            var createLinkRequest = _mapper.Map<CreateLinkRequest>(command);
            
            return await _linksService.CreateAsync(createLinkRequest);
        }
    }
}