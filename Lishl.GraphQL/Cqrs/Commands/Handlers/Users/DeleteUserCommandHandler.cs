using System;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Services;
using Lishl.GraphQL.Cqrs.Commands.Users;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers.Users
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Guid>
    {
        private readonly IUsersService _usersService; 
            
        public DeleteUserCommandHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }
        
        public async Task<Guid> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            await _usersService.DeleteAsync(command.UserId);

            return command.UserId;
        }
    }
}