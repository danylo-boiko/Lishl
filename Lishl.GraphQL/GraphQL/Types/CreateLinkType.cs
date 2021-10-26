using GraphQL.Types;
using Lishl.Core.Models;

namespace Lishl.GraphQL.GraphQL.Types
{
    public sealed class CreateLinkType : InputObjectGraphType<Link>
    {
        public CreateLinkType()
        {
            Field(l => l.UserId).Description("Id of stored user");
            Field(l => l.FullUrl).Description("Full url");
            Field(l => l.ShortUrl).Description("Short url");
        }
    }
}