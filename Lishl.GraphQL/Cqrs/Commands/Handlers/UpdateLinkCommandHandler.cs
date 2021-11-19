using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Core.Models;
using Lishl.Core.Requests;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers
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
        
        public async Task<Link> Handle(UpdateLinkCommand request, CancellationToken cancellationToken)
        {
            var updateLinkRequest = _mapper.Map<UpdateLinkRequest>(request);
            
            return await _linksService.UpdateAsync(request.Id, updateLinkRequest);
        }
    }
}