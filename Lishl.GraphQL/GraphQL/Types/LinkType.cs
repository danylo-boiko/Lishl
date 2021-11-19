using GraphQL.Types;
using Lishl.Core.Models;
using Lishl.GraphQL.Cqrs.Queries;
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
            Field<ListGraphType<LinkFollowType>>("follows", "Follows of the link", resolve: u=>u.Source.Follows);

            FieldAsync<UserType>("user", "User details", resolve: async content => await mediator.Send(new GetUserByIdQuery
            {
                UserId = content.Source.UserId
            }));
        }
    }
}