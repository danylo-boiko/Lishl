using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Commands.Handlers
{
    public class DeleteUserCommandHandler: AsyncRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteAsync(request.Id);
        }
    }
}