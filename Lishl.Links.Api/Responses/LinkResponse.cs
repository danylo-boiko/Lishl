using System;
using System.Collections.Generic;
using Lishl.Core.Models;

namespace Lishl.Links.Api.Responses
{
    public class LinkResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }
        public IEnumerable<LinkFollow> Follows { get; set; }
    }
}