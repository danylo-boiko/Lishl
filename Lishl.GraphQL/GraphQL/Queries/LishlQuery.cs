using System;
using GraphQL;
using GraphQL.Types;
using Lishl.GraphQL.GraphQL.Types;
using MediatR;

namespace Lishl.GraphQL.GraphQL.Queries
{
    public class LishlQuery : ObjectGraphType
    {
        public LishlQuery(IMediator mediator)
        {
            Name = "Query";

            Field<UserType>("user", arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the user" }
            ), resolve: context => mediator.Send(new GetUserByIdQuery(context.GetArgument<Guid>("id"))));
            
            Field<UserType>("link", arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the link" }
            ), resolve: context => mediator.Send(new GetLinkByIdQuery(context.GetArgument<Guid>("id"))));
            
            Field<ListGraphType<UserType>>("users", resolve: _ => mediator.Send(new GetUsersQuery()));
            Field<ListGraphType<LinkType>>("links", resolve: _ => mediator.Send(new GetLinksQuery()));
        }
    }
}