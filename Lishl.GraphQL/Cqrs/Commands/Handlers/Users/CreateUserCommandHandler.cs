using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Core.Models;
using Lishl.Core.Requests.User;
using Lishl.Core.Services;
using Lishl.GraphQL.Cqrs.Commands.Users;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUsersService _usersService; 
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }
        
        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var createUserRequest = _mapper.Map<CreateUserRequest>(command);
            
            return await _usersService.CreateAsync(createUserRequest);
        }
    }
}