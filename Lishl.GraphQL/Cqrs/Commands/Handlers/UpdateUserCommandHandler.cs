using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Core.Models;
using Lishl.Core.Requests;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUsersService _usersService; 
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }
        
        public async Task<User> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var updateUserRequest = _mapper.Map<UpdateUserRequest>(command);
            
            return await _usersService.UpdateAsync(command.Id, updateUserRequest);
        }
    }
}