using Lishl.Core.Enums;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Commands
{
    public record CreateUserCommand : IRequest<User>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public UserRole[] Roles { get; set; }
    }
}