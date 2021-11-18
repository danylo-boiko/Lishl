using Lishl.Core.Models;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Queries
{
    public record GetLinkByShortUrlQuery: IRequest<Link>
    {
        public string ShortUrl { get; set; }
    }
}