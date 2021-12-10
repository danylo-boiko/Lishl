using GraphQL.Types;
using Lishl.Core.Requests.Link;
using Lishl.GraphQL.GraphQL.Types.LinkFollow;

namespace Lishl.GraphQL.GraphQL.Types.Link
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