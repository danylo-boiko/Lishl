using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries.Links
{
    public record GetLinkByShortUrlQuery : IRequest<Link>
    {
        public string ShortUrl { get; set; }
    }
}