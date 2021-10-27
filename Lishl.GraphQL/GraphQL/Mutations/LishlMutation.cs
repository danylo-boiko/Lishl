using System;
using GraphQL;
using GraphQL.Types;
using Lishl.Core.GraphQL.Requests;
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
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CreateUserType>> { Name = "user" }),
                resolve: context =>
                {
                    var userRequest = context.GetArgument<CreateUserRequest>("user");
                    
                    return mediator.Send(new CreateUserCommand
                    {
                        Username = userRequest.Username,
                        Email = userRequest.Email,
                        Password = userRequest.Password,
                        Roles = userRequest.Roles
                    });
                });
            
            FieldAsync<LinkType>("createLink",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CreateLinkType>> { Name = "link" }),
                resolve: async context =>
                {
                    var linkRequest = context.GetArgument<CreateLinkRequest>("link");
                    
                    var storedUser = await mediator.Send(new GetUserByIdQuery { UserId = linkRequest.UserId });
                    if (storedUser == null)
                    {
                        context.Errors.Add(new ExecutionError($"Couldn't find user with id {linkRequest.UserId}."));
                        return null;
                    }
                    
                    return await mediator.Send(new CreateLinkCommand
                    {
                        UserId = linkRequest.UserId,
                        FullUrl = linkRequest.FullUrl,
                        ShortUrl = linkRequest.ShortUrl
                    });
                });
            
            FieldAsync<UserType>("updateUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id", Description = "Id of the user" },
                    new QueryArgument<NonNullGraphType<UpdateUserType>> { Name = "user" }),
                resolve: async context =>
                {
                    var userId = context.GetArgument<Guid>("id");
                    var userRequest = context.GetArgument<UpdateUserRequest>("user");
                    
                    var storedUser = await mediator.Send(new GetUserByIdQuery{UserId = userId});
                    if (storedUser == null)
                    {
                        context.Errors.Add(new ExecutionError($"Couldn't find user with id {userId}."));
                        return null;
                    }
                    
                    return await mediator.Send(new UpdateUserCommand
                    {
                        Id = userId,
                        Username = userRequest.Username,
                        Email = userRequest.Email,
                        Password = userRequest.Password,
                        Roles = userRequest.Roles
                    });
                });

            FieldAsync<LinkType>("updateLink",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id", Description = "Id of the link" },
                    new QueryArgument<NonNullGraphType<UpdateLinkType>> { Name = "link" }),
                resolve: async context =>
                {
                    var linkId = context.GetArgument<Guid>("id");
                    var linkRequest = context.GetArgument<UpdateLinkRequest>("link");

                    var storedLink = await mediator.Send(new GetLinkByIdQuery { LinkId = linkId });
                    if (storedLink == null)
                    {
                        context.Errors.Add(new ExecutionError($"Couldn't find link with id {linkId}."));
                        return null;
                    }

                    var storedUser = await mediator.Send(new GetUserByIdQuery{UserId = linkRequest.UserId});
                    if (storedUser == null)
                    {
                        context.Errors.Add(new ExecutionError($"Couldn't find user with id {linkRequest.UserId}."));
                        return null;
                    }

                    return await mediator.Send(new UpdateLinkCommand
                    {
                        Id = linkId,
                        UserId = linkRequest.UserId,
                        FullUrl = linkRequest.FullUrl,
                        ShortUrl = linkRequest.ShortUrl,
                        Follows = linkRequest.Follows
                    });
                });
            
            FieldAsync<StringGraphType>("deleteUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id", Description = "Id of the stored user"}),
                resolve: async context =>
                {
                    var userId = context.GetArgument<Guid>("id");
                    
                    var storedUser = await mediator.Send(new GetUserByIdQuery { UserId = userId });
                    if (storedUser == null)
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
                    
                    var storedLink = await mediator.Send(new GetLinkByIdQuery { LinkId = linkId });
                    if (storedLink == null)
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