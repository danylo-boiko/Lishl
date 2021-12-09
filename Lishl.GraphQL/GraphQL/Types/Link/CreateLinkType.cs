using GraphQL.Types;
using Lishl.Core.Requests.Link;

namespace Lishl.GraphQL.GraphQL.Types.Link
{
    public sealed class CreateLinkType : InputObjectGraphType<CreateLinkRequest>
    {
        public CreateLinkType()
        {
            Field(l => l.UserId).Description("Id of stored user");
            Field(l => l.FullUrl).Description("Full url");
        }
    }
}