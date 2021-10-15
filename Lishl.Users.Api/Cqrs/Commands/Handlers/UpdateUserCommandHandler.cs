using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Commands.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUsersRepository _usersRepository;

        public UpdateUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = request.Id,
                Username = request.Username,
                Email = request.Email,
                HashedPassword = request.HashedPassword,
                Roles = request.Roles
            };

            await _usersRepository.UpdateAsync(user);
            
            return await _usersRepository.GetAsync(user.Id);
        }
    }
}