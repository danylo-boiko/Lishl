using System;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Users
{
    public record GetUserByIdQuery : IRequest<User>
    {
        public Guid UserId { get; set; } 
    }
}