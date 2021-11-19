using System;
using System.ComponentModel.DataAnnotations;

namespace Lishl.Core.Requests
{
    public class CreateQRCodeRequest
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Url { get; set; }
    }
}