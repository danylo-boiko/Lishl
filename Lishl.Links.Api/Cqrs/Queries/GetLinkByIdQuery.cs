using System;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Queries
{
    public class GetLinkByIdQuery : IRequest<Link>
    {
        public Guid Id { get; set; }
    }
}