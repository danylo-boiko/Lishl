using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Queries.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUserByIdQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        
        public async Task<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            return await _usersRepository.GetAsync(query.Id); 
        }
    }
}