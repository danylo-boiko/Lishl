using System;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Links
{
    public record GetLinkByIdQuery : IRequest<Link>
    {
        public Guid LinkId { get; set; }
    }
}