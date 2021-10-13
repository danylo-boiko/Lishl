using System;
using Lishl.Core.Enums;

namespace Lishl.Users.Api.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserRole[] Roles { get; set; }
    }
}