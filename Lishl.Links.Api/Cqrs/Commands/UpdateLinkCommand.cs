﻿using System;
using System.Collections.Generic;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Commands
{
    public class UpdateLinkCommand : IRequest<Link>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }
        public IEnumerable<LinkFollow> Follows { get; set; }
    }
}