using GraphQL.Types;

namespace Lishl.GraphQL.GraphQL.Types.LinkFollow
{
    public sealed class LinkFollowType : ObjectGraphType<Core.Models.LinkFollow>
    {
        public LinkFollowType()
        {
            Name = "LinkFollow";
            Description = "Follow of the link";
            
            Field(lf => lf.Id).Description("Identifier of the link follow");
            Field(lf => lf.Date).Description("Date of the follow");
            Field(lf => lf.IpAddress).Description("IP address the follow");
        }
    }
}