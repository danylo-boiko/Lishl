using System;
using System.Collections.Generic;

namespace Lishl.Core.Models
{
    public class Link : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }
        public List<LinkFollow> Follows { get; set; }
    }
}