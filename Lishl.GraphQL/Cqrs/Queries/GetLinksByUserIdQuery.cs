using System;
using System.Collections.Generic;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries
{
    public record GetLinksByUserIdQuery : IRequest<IEnumerable<Link>>
    {
        public Guid UserId { get; set; }
    }
}