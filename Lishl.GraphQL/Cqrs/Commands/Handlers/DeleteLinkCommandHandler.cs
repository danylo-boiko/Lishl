using System;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers
{
    public class DeleteLinkCommandHandler :  IRequestHandler<DeleteLinkCommand, Guid>
    {
        private readonly ILinksService _linksService; 
        
        public DeleteLinkCommandHandler(ILinksService linksService)
        {
            _linksService = linksService;
        }
        
        public async Task<Guid> Handle(DeleteLinkCommand request, CancellationToken cancellationToken)
        {
            await _linksService.DeleteAsync(request.LinkId);

            return request.LinkId;
        }
    }
}