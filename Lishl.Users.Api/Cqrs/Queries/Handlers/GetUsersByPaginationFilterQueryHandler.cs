using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Queries.Handlers
{
    public class GetUsersByPaginationFilterQueryHandler : IRequestHandler<GetUsersByPaginationFilterQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersByPaginationFilterQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<List<User>> Handle(GetUsersByPaginationFilterQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAsync(request.PaginationFilter);
        }
    }
}