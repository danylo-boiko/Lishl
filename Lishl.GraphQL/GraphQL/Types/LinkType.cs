using GraphQL.Types;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.GraphQL.Types
{
    public sealed class LinkType : ObjectGraphType<Link>
    {
        public LinkType(IMediator mediator)
        {
            Name = "Link";
            Description = "Created link";

            Field(l => l.Id).Description("Identifier of the link");
            Field(l => l.FullUrl).Description("Full url of the link");
            Field(l => l.ShortUrl).Description("Short url of the link");
            Field(l => l.Follows).Description("Follows of the link");

            Field<UserType>("user", "User details", resolve: content => mediator.Send(new GetUserByIdQuery(content.Source.UserId)));
        }
    }
}