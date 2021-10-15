using System;

namespace Lishl.Links.Api.Requests
{
    public class CreateLinkRequest
    {
        public Guid UserId { get; set; }
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}