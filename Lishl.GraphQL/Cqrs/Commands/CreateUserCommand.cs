using System.Collections.Generic;
using Lishl.Core.Enums;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands
{
    public record CreateUserCommand : IRequest<User>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UserRole> Roles { get; set; }
    }
}