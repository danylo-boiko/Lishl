using GraphQL.Types;
using Lishl.Core.Models;

namespace Lishl.GraphQL.GraphQL.Types
{
    public sealed class LinkInputType : InputObjectGraphType<Link>
    {
        public LinkInputType()
        {
            Field(l => l.UserId).Description("Id of stored user");
            Field(l => l.FullUrl).Description("Full url");
            Field(l => l.ShortUrl).Description("Short url");
        }
    }
}