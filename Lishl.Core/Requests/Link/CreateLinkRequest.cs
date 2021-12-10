using System;
using System.ComponentModel.DataAnnotations;

namespace Lishl.Core.Requests.Link
{
    public class CreateLinkRequest
    {
        [Required]
        public Guid UserId { get; set; }
        
        [Required]
        public string FullUrl { get; set; }
    }
}