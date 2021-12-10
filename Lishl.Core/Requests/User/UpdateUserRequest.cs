using System.Collections.Generic;
using Lishl.Core.Enums;

namespace Lishl.Core.Requests.User
{
    public class UpdateUserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UserRole> Roles { get; set; }
    }
}