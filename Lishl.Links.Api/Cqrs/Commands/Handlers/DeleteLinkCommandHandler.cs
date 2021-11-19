using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Commands.Handlers
{
    public class DeleteLinkCommandHandler :  AsyncRequestHandler<DeleteLinkCommand>
    {
        private readonly ILinksRepository _linksRepository;

        public DeleteLinkCommandHandler(ILinksRepository linksRepository)
        {
            _linksRepository = linksRepository;
        }
        
        protected override async Task Handle(DeleteLinkCommand command, CancellationToken cancellationToken)
        {
            await _linksRepository.DeleteAsync(command.Id);
        }
    }
}