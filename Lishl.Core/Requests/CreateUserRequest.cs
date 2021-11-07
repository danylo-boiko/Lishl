﻿using System.ComponentModel.DataAnnotations;
using Lishl.Core.Enums;

namespace Lishl.Core.Requests
{
    public class CreateUserRequest
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        public UserRole[] Roles { get; set; }
    }
}