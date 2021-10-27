using GraphQL.Types;
using Lishl.Core.GraphQL.Requests;

namespace Lishl.GraphQL.GraphQL.Types
{
    public sealed class UpdateLinkType : InputObjectGraphType<UpdateLinkRequest>
    {
        public UpdateLinkType()
        {
            Field(l => l.UserId).Description("Id of stored user");
            Field(l => l.FullUrl).Description("Full url");
            Field(l => l.ShortUrl).Description("Short url");
            Field<ListGraphType<LinkFollowInputType>>("follows", "Follows of the link", resolve: u=>u.Source.Follows);
        }
    }
}