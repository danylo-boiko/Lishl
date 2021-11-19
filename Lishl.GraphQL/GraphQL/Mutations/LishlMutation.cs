using System;
using GraphQL;
using GraphQL.Types;
using Lishl.Core.Requests;
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

            FieldAsync<UserType>("createUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CreateUserType>> { Name = "user" }),
                resolve: async context =>
                {
                    try
                    {
                        var userRequest = context.GetArgument<CreateUserRequest>("user");
                        
                        return await mediator.Send(new CreateUserCommand
                        {
                            Username = userRequest.Username,
                            Email = userRequest.Email,
                            Password = userRequest.Password,
                            Roles = userRequest.Roles
                        });
                    }
                    catch (ExecutionError e)
                    {
                        context.Errors.Add(new ExecutionError(e.Message));
                        return null;
                    }
                });
            
            FieldAsync<LinkType>("createLink",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CreateLinkType>> { Name = "link" }),
                resolve: async context =>
                {
                    try
                    {
                        var linkRequest = context.GetArgument<CreateLinkRequest>("link");

                        await mediator.Send(new GetUserByIdQuery { UserId = linkRequest.UserId });

                        return await mediator.Send(new CreateLinkCommand
                        {
                            UserId = linkRequest.UserId,
                            FullUrl = linkRequest.FullUrl,
                        });
                    }
                    catch (ExecutionError e)
                    {
                        context.Errors.Add(new ExecutionError(e.Message));
                        return null;
                    }
                });
            
            FieldAsync<UserType>("updateUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id", Description = "Id of the user" },
                    new QueryArgument<NonNullGraphType<UpdateUserType>> { Name = "user" }),
                resolve: async context =>
                {
                    try
                    {
                        var userId = context.GetArgument<Guid>("id");
                        var userRequest = context.GetArgument<UpdateUserRequest>("user");
                        
                        return await mediator.Send(new UpdateUserCommand
                        {
                            Id = userId,
                            Username = userRequest.Username,
                            Email = userRequest.Email,
                            Password = userRequest.Password,
                            Roles = userRequest.Roles
                        });
                    }
                    catch (ExecutionError e)
                    {
                        context.Errors.Add(new ExecutionError(e.Message));
                        return null;
                    }
                });

            FieldAsync<LinkType>("updateLink", arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id", Description = "Id of the link" },
                    new QueryArgument<NonNullGraphType<UpdateLinkType>> { Name = "link" }),
                resolve: async context =>
                {
                    try
                    {
                        var linkId = context.GetArgument<Guid>("id");
                        var linkRequest = context.GetArgument<UpdateLinkRequest>("link");

                        await mediator.Send(new GetUserByIdQuery { UserId = linkRequest.UserId });

                        return await mediator.Send(new UpdateLinkCommand
                        {
                            Id = linkId,
                            UserId = linkRequest.UserId,
                            FullUrl = linkRequest.FullUrl,
                            ShortUrl = linkRequest.ShortUrl,
                            Follows = linkRequest.Follows
                        });
                    }
                    catch (ExecutionError e)
                    {
                        context.Errors.Add(new ExecutionError(e.Message));
                        return null;
                    }
                });
            
            FieldAsync<StringGraphType>("deleteUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id", Description = "Id of the stored user"}),
                resolve: async context =>
                {
                    var userId = context.GetArgument<Guid>("id");
                    try
                    {
                        var deletedUserId = await mediator.Send(new DeleteUserCommand { UserId = userId });

                        return $"User with id {deletedUserId} has been successfully deleted.";
                    }
                    catch (Exception)
                    {
                        context.Errors.Add(new ExecutionError($"Couldn't find user with id {userId}."));
                        return null;
                    }
                });
            
            FieldAsync<StringGraphType>("deleteLink",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id", Description = "Id of the stored link"}),
                resolve: async context =>
                {
                    var linkId = context.GetArgument<Guid>("id");
                    try
                    {
                        var deletedLinkId = await mediator.Send(new DeleteLinkCommand { LinkId = linkId });

                        return $"Link with id {deletedLinkId} has been successfully deleted.";
                    }
                    catch (Exception)
                    {
                        context.Errors.Add(new ExecutionError($"Couldn't find link with id {linkId}."));
                        return null;
                    }
                });
        }
    }
}