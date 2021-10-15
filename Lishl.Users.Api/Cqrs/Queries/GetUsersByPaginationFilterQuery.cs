using System.Collections.Generic;
using Lishl.Core;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Queries
{
    public class GetUsersByPaginationFilterQuery : IRequest<List<User>>
    {
        public PaginationFilter PaginationFilter { get; set; }
    }
}