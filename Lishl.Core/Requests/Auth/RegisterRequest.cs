using System.ComponentModel.DataAnnotations;

namespace Lishl.Core.Requests.Auth
{
    public class RegisterRequest : LoginRequest
    {
        [Required]
        public string Username { get; init; }
    }
}