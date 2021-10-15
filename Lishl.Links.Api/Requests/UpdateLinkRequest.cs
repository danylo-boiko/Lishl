using System;
using System.Collections.Generic;
using Lishl.Core.Models;

namespace Lishl.Links.Api.Requests
{
    public class UpdateLinkRequest
    {
        public Guid UserId { get; set; }
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }
        public IEnumerable<LinkFollow> Follows { get; set; }
    }
}