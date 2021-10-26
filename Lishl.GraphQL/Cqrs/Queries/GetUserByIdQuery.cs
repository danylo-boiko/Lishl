using System;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries
{
    public record GetUserByIdQuery(Guid UserId) : IRequest<User>;
}