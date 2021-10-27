using System;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands
{
    public record DeleteUserCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
    }
}