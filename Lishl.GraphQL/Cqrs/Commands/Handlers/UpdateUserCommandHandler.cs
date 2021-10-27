using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.GraphQL.Requests;
using Lishl.Core.Models;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUsersService _usersService; 
        
        public UpdateUserCommandHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }
        
        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _usersService.UpdateAsync(request.Id, new UpdateUserRequest
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                Roles = request.Roles
            });
        }
    }
}