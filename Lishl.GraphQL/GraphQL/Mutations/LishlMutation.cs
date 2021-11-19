using System;
using AutoMapper;
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
        public LishlMutation(IMediator mediator, IMapper mapper)
        {
            Name = "Mutation";

            FieldAsync<UserType>("createUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CreateUserType>> { Name = "user" }),
                resolve: async context =>
                {
                    try
                    {
                        var userRequest = context.GetArgument<CreateUserRequest>("user");
                        
                        return await mediator.Send(mapper.Map<CreateUserCommand>(userRequest));
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

                        return await mediator.Send(mapper.Map<CreateLinkCommand>(linkRequest));
                    }
                    catch (ExecutionError e)
                    {
                        context.Errors.Add(new ExecutionError(e.Message));
                        return null;
                    }
                });
            
            FieldAsync<QRCodeType>("createQRCode",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CreateQRCodeType>> { Name = "qrcode" }),
                resolve: async context =>
                {
                    try
                    {
                        var qrCodeRequest = context.GetArgument<CreateQRCodeRequest>("qrcode");

                        await mediator.Send(new GetUserByIdQuery { UserId = qrCodeRequest.UserId });

                        return await mediator.Send(mapper.Map<CreateQRCodeCommand>(qrCodeRequest));
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

                        var updateUserCommand = mapper.Map<UpdateUserCommand>(userRequest);
                        updateUserCommand.Id = userId;
                        
                        return await mediator.Send(updateUserCommand);
                    }
                    catch (ExecutionError e)
                    {
                        context.Errors.Add(new ExecutionError(e.Message));
                        return null;
                    }
                });

            FieldAsync<LinkType>("updateLink",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id", Description = "Id of the link" }, 
                    new QueryArgument<NonNullGraphType<UpdateLinkType>> { Name = "link" }),
                resolve: async context =>
                {
                    try
                    {
                        var linkId = context.GetArgument<Guid>("id");
                        var linkRequest = context.GetArgument<UpdateLinkRequest>("link");

                        await mediator.Send(new GetUserByIdQuery { UserId = linkRequest.UserId });

                        var updateLinkCommand = mapper.Map<UpdateLinkCommand>(linkRequest);
                        updateLinkCommand.Id = linkId;
                        
                        return await mediator.Send(updateLinkCommand);
                    }
                    catch (ExecutionError e)
                    {
                        context.Errors.Add(new ExecutionError(e.Message));
                        return null;
                    }
                });
            
            FieldAsync<QRCodeType>("updateQRCode",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id", Description = "Id of the qr code" }, 
                    new QueryArgument<NonNullGraphType<UpdateQRCodeType>> { Name = "qrcode" }),
                resolve: async context =>
                {
                    try
                    {
                        var qrCodeId = context.GetArgument<Guid>("id");
                        var qrCodeRequest = context.GetArgument<UpdateQRCodeRequest>("qrcode");

                        await mediator.Send(new GetUserByIdQuery { UserId = qrCodeRequest.UserId });

                        var updateQRCodeCommand = mapper.Map<UpdateQRCodeCommand>(qrCodeRequest);
                        updateQRCodeCommand.Id = qrCodeId;
                        
                        return await mediator.Send(updateQRCodeCommand);
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
            
            FieldAsync<StringGraphType>("deleteQRCode",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id", Description = "Id of the stored qr code"}),
                resolve: async context =>
                {
                    var qrCodeId = context.GetArgument<Guid>("id");
                    try
                    {
                        var deletedQRCodeId = await mediator.Send(new DeleteQRCodeCommand { QRCodeId = qrCodeId });

                        return $"QR code with id {deletedQRCodeId} has been successfully deleted.";
                    }
                    catch (Exception)
                    {
                        context.Errors.Add(new ExecutionError($"Couldn't find QR code link with id {qrCodeId}."));
                        return null;
                    }
                });
        }
    }
}