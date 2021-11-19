using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Queries.Handlers
{
    public class GetUsersByPaginationFilterQueryHandler : IRequestHandler<GetUsersByPaginationFilterQuery, IEnumerable<User>>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUsersByPaginationFilterQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        
        public async Task<IEnumerable<User>> Handle(GetUsersByPaginationFilterQuery query, CancellationToken cancellationToken)
        {
            return await _usersRepository.GetAsync(query.PaginationFilter);
        }
    }
}