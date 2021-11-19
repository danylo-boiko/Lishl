using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Queries.Handlers
{
    public class GetUserByEmailQueryHandler: IRequestHandler<GetUserByEmailQuery, User>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUserByEmailQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        
        public async Task<User> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
        {
            return await _usersRepository.GetByEmailAsync(query.Email); 
        }
    }
}