using System.ComponentModel.DataAnnotations;

namespace Lishl.Core.Requests
{
    public class RegisterRequest : LoginRequest
    {
        [Required]
        public string Username { get; init; }
    }
}