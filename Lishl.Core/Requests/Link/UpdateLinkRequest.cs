using System;
using System.Collections.Generic;
using Lishl.Core.Models;

namespace Lishl.Core.Requests.Link
{
    public class UpdateLinkRequest
    {
        public Guid UserId { get; set; }
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }
        public List<LinkFollow> Follows { get; set; }
    }
}