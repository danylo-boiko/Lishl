using System;
using System.Collections.Generic;
using Lishl.Core.Enums;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands.Users
{
    public record UpdateUserCommand : IRequest<User>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UserRole> Roles { get; set; }
    }
}