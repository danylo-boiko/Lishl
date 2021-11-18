using System;
using System.Collections.Generic;
using Lishl.Core.Enums;

namespace Lishl.Users.Api.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<UserRole> Roles { get; set; }
    }
}