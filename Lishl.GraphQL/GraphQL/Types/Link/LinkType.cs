using GraphQL.Types;
using Lishl.GraphQL.Cqrs.Queries.Users;
using Lishl.GraphQL.GraphQL.Types.LinkFollow;
using Lishl.GraphQL.GraphQL.Types.User;
using MediatR;

namespace Lishl.GraphQL.GraphQL.Types.Link
{
    public sealed class LinkType : ObjectGraphType<Core.Models.Link>
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