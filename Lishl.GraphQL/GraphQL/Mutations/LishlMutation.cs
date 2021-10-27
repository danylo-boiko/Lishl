﻿using System;
using GraphQL;
using GraphQL.Types;
using Lishl.Core.Models;
using Lishl.GraphQL.Cqrs.Commands;
using Lishl.GraphQL.Cqrs.Queries;
using Lishl.GraphQL.GraphQL.Types;
using MediatR;

namespace Lishl.GraphQL.GraphQL.Mutations
{
    public class LishlMutation : ObjectGraphType
    {
        public LishlMutation(IMediator mediator)
        {
            Name = "Mutation";

            Field<UserType>("createUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }),
                resolve: context =>
                {
                    var user = context.GetArgument<User>("user");
                    return mediator.Send(new CreateUserCommand
                    {
                        Username = user.Username,
                        Email = user.Email,
                        Password = user.HashedPassword,
                        Roles = user.Roles
                    });
                });
            
            FieldAsync<LinkType>("createLink",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LinkInputType>> { Name = "link" }),
                resolve: async context =>
                {
                    var link = context.GetArgument<Link>("link");
                    var user = await mediator.Send(new GetUserByIdQuery { UserId = link.UserId });

                    if (user == null)
                    {
                        context.Errors.Add(new ExecutionError($"Couldn't find user with id {link.UserId}."));
                        return null;
                    }
                    
                    return await mediator.Send(new CreateLinkCommand
                    {
                        UserId = link.UserId,
                        FullUrl = link.FullUrl,
                        ShortUrl = link.ShortUrl
                    });
                });
            
            FieldAsync<StringGraphType>("deleteUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id", Description = "Id of the stored user"}),
                resolve: async context =>
                {
                    var userId = context.GetArgument<Guid>("id");
                    var user = await mediator.Send(new GetUserByIdQuery { UserId = userId });

                    if (user == null)
                    {
                        context.Errors.Add(new ExecutionError($"Couldn't find user with id {userId}."));
                        return null;
                    }

                    var deletedUserId = await mediator.Send(new DeleteUserCommand { UserId = userId });

                    return $"User with id {deletedUserId} has been successfully deleted.";
                });
            
            FieldAsync<StringGraphType>("deleteLink",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id", Description = "Id of the stored link"}),
                resolve: async context =>
                {
                    var linkId = context.GetArgument<Guid>("id");
                    var link = await mediator.Send(new GetLinkByIdQuery { LinkId = linkId });

                    if (link == null)
                    {
                        context.Errors.Add(new ExecutionError($"Couldn't find link with id {linkId}."));
                        return null;
                    }

                    var deletedLinkId = await mediator.Send(new DeleteLinkCommand { LinkId = linkId });

                    return $"Link with id {deletedLinkId} has been successfully deleted.";
                });
        }
    }
}