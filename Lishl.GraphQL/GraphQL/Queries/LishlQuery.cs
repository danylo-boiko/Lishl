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
                    try
                    {
                        var userId = context.GetArgument<Guid>("id");
                        return await mediator.Send(new GetUserByIdQuery { UserId = userId });
                    }
                    catch (ExecutionError e)
                    {
                        context.Errors.Add(new ExecutionError(e.Message));
                        return null;
                    }
                });

            FieldAsync<LinkType>("link", 
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "Id of the link" }),
                resolve: async context =>
                {
                    try
                    {
                        var linkId = context.GetArgument<Guid>("id");
                        return await mediator.Send(new GetLinkByIdQuery { LinkId = linkId });
                    }
                    catch (ExecutionError e)
                    {
                        context.Errors.Add(new ExecutionError(e.Message));
                        return null;
                    }
                });

            Field<ListGraphType<UserType>>("users", resolve: _ => mediator.Send(new GetUsersQuery()));
            Field<ListGraphType<LinkType>>("links", resolve: _ => mediator.Send(new GetLinksQuery()));
        }
    }
}