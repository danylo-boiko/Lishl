using System;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}