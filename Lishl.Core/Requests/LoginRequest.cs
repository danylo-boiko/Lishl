﻿using System.ComponentModel.DataAnnotations;

namespace Lishl.Core.Requests
{
    public class LoginRequest
    {
        [Required] 
        public string Email { get; set; } 
        
        [Required] 
        public string Password { get; set; }
    }
}