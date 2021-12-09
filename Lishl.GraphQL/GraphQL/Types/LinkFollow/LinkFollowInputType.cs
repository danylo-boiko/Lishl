using GraphQL.Types;

namespace Lishl.GraphQL.GraphQL.Types.LinkFollow
{
    public sealed class LinkFollowInputType : InputObjectGraphType<Core.Models.LinkFollow>
    {
        public LinkFollowInputType()
        {
            Field(lf => lf.Date).Description("Current date");
            Field(lf => lf.IpAddress).Description("IP address of the follow");
        }
    }
}