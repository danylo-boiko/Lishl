using System.Collections.Generic;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Users
{
    public record GetUsersQuery : IRequest<IEnumerable<User>>;
}