using System;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Commands
{
    public record DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}