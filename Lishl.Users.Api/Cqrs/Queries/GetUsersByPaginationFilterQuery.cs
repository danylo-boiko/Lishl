using System.Collections.Generic;
using Lishl.Core;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Queries
{
    public record GetUsersByPaginationFilterQuery : IRequest<IEnumerable<User>>
    {
        public PaginationFilter PaginationFilter { get; set; }
    }
}