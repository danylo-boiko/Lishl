using System.Collections.Generic;
using Lishl.Core;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Queries
{
    public record GetLinksByPaginationFilterQuery :  IRequest<IEnumerable<Link>>
    {
        public PaginationFilter PaginationFilter { get; set; }
    }
}