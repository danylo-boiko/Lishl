using System.Threading;
using System.Threading.Tasks;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Handlers
{
    public class GetUserByIdQueryHandler: IRequestHandler<GetUserByIdQuery, User>
    {
        public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}