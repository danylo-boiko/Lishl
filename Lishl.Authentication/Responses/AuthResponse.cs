using System;

namespace Lishl.Authentication.Responses
{
    public class AuthResponse
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}