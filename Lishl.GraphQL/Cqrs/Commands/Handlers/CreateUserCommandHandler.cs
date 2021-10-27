using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.GraphQL.Requests;
using Lishl.Core.Models;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUsersService _usersService; 
        
        public CreateUserCommandHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }
        
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _usersService.CreateAsync(new CreateUserRequest
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                Roles = request.Roles
            });
        }
    }
}