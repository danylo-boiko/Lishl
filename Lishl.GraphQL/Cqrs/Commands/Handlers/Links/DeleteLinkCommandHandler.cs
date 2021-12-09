using System;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Services;
using Lishl.GraphQL.Cqrs.Commands.Links;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers.Links
{
    public class DeleteLinkCommandHandler :  IRequestHandler<DeleteLinkCommand, Guid>
    {
        private readonly ILinksService _linksService; 
        
        public DeleteLinkCommandHandler(ILinksService linksService)
        {
            _linksService = linksService;
        }
        
        public async Task<Guid> Handle(DeleteLinkCommand command, CancellationToken cancellationToken)
        {
            await _linksService.DeleteAsync(command.LinkId);

            return command.LinkId;
        }
    }
}