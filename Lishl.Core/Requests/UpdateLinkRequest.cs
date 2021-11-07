using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lishl.Core.Models;

namespace Lishl.Core.Requests
{
    public class UpdateLinkRequest: CreateLinkRequest
    {
        [Required]
        public IEnumerable<LinkFollow> Follows { get; set; }
    }
}