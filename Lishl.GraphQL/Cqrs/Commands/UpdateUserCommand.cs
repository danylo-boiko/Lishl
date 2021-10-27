using System;
using Lishl.Core.Enums;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands
{
    public record UpdateUserCommand : IRequest<User>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole[] Roles { get; set; }
    }
}