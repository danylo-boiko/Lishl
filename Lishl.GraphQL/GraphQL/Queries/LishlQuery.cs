using System;
using GraphQL;
using GraphQL.Types;
using Lishl.GraphQL.Cqrs.Queries;
using Lishl.GraphQL.GraphQL.Types;
using MediatR;

namespace Lishl.GraphQL.GraphQL.Queries
{
    public class LishlQuery : ObjectGraphType
    {
        public LishlQuery(IMediator mediator)
        {
            Name = "Query";

            FieldAsync<UserType>("user", 
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "Id of the user" }), 
                resolve: async context =>
                {
                    var userId = context.GetArgument<Guid>("id");
                    var user = await mediator.Send(new GetUserByIdQuery { UserId = userId});
                    
                    if (user == null)
                    {
                        context.Errors.Add(new ExecutionError($"Couldn't find user with id {userId}."));
                        return null;
                    }

                    return user;
                });

            FieldAsync<LinkType>("link", 
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "Id of the link" }),
                resolve: async context =>
                {
                    var linkId = context.GetArgument<Guid>("id");
                    var link = await mediator.Send(new GetLinkByIdQuery { LinkId = linkId });
                    
                    if (link == null)
                    {
                        context.Errors.Add(new ExecutionError($"Couldn't find link with id {linkId}."));
                        return null;
                    }

                    return link;
                });

            Field<ListGraphType<UserType>>("users", resolve: _ => mediator.Send(new GetUsersQuery()));
            Field<ListGraphType<LinkType>>("links", resolve: _ => mediator.Send(new GetLinksQuery()));
        }
    }
}