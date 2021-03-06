using System;
using System.Collections.Generic;
using Lishl.Core.Enums;

namespace Lishl.Core.Models
{
    public class User : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public List<UserRole> Roles { get; set; }
    }
}