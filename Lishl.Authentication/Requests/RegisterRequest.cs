using System.ComponentModel.DataAnnotations;

namespace Lishl.Authentication.Requests
{
    public class RegisterRequest : LoginRequest
    {
        [Required]
        public string Username { get; init; }
    }
}