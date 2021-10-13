using System;
using Lishl.Core.Enums;

namespace Lishl.Core.Models
{
    public class User : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public UserRole[] Roles { get; set; }
    }
}