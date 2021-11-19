using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Commands.Handlers
{
    public class DeleteUserCommandHandler : AsyncRequestHandler<DeleteUserCommand>
    {
        private readonly IUsersRepository _usersRepository;

        public DeleteUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        protected override async Task Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            await _usersRepository.DeleteAsync(command.Id);
        }
    }
}