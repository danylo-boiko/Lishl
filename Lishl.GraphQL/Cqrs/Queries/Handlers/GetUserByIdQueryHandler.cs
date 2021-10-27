using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Services;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Handlers
{
    public class GetUserByIdQueryHandler: IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUsersService _usersService;

        public GetUserByIdQueryHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }
        
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _usersService.GetAsync(request.UserId);
        }
    }
}