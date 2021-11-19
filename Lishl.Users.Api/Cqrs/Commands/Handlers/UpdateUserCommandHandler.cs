using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Commands.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<User> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(command);

            await _usersRepository.UpdateAsync(user);
            
            return await _usersRepository.GetAsync(user.Id);
        }
    }
}