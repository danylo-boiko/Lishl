using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Commands.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

            await _userRepository.Update(user);
            
            return await _userRepository.GetById(user.Id);
        }
    }
}