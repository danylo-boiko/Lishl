using System;
using System.ComponentModel.DataAnnotations;

namespace Lishl.Core.GraphQL.Requests
{
    public class CreateLinkRequest
    {
        [Required]
        public Guid UserId { get; set; }
        
        [Required]
        public string FullUrl { get; set; }
        
        [Required]
        public string ShortUrl { get; set; }
    }
}