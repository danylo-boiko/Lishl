using System;
using MediatR;
using Lishl.Core.Models;

namespace Lishl.GraphQL.Cqrs.Commands.Links
{
    public record CreateLinkCommand : IRequest<Link>
    {
        public Guid UserId { get; set; }
        public string FullUrl { get; set; }
    }
}