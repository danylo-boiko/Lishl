using Lishl.Core.Enums;

namespace Lishl.Core.Requests
{
    public class UpdateUserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole[] Roles { get; set; }
    }
}