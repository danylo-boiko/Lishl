using System.ComponentModel.DataAnnotations;

namespace Lishl.Authentication.Requests
{
    public class LoginRequest
    {
        [Required] 
        public string Email { get; set; } 
        
        [Required] 
        public string Password { get; set; }
    }
}