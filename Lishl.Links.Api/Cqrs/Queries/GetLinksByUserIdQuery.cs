using System;
using System.Collections.Generic;
using Lishl.Core;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Queries
{
    public record GetLinksByUserIdQuery : IRequest<IEnumerable<Link>>
    {
        public Guid UserId { get; set; }
        public PaginationFilter PaginationFilter { get; set; }
    }
}