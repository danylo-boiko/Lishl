using GraphQL.Types;
using Lishl.Core.Models;

namespace Lishl.GraphQL.GraphQL.Types
{
    public sealed class LinkFollowType : ObjectGraphType<LinkFollow>
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