using System;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Commands
{
    public record CreateLinkCommand : IRequest<Link>
    {
        public Guid UserId { get; set; }
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}