using GraphQL.Types;
using Lishl.Core.Models;

namespace Lishl.GraphQL.GraphQL.Types
{
    public sealed class CreateLinkFollowType : InputObjectGraphType<LinkFollow>
    {
        public CreateLinkFollowType()
        {
            Field(lf => lf.Date).Description("Current date");
            Field(lf => lf.IpAddress).Description("IP address of the follow");
        }
    }
}