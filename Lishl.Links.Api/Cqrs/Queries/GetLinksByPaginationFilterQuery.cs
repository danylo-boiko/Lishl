using System.Collections.Generic;
using Lishl.Core;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Queries
{
    public class GetLinksByPaginationFilterQuery :  IRequest<List<Link>>
    {
        public PaginationFilter PaginationFilter { get; set; }
    }
}