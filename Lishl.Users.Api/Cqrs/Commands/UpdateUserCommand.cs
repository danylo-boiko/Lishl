using System;
using Lishl.Core.Enums;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Commands
{
    public record UpdateUserCommand : IRequest<User>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public UserRole[] Roles { get; set; }
    }
}