using System;
using GraphQL;
using GraphQL.Types;
using Lishl.GraphQL.Cqrs.Queries.Links;
using Lishl.GraphQL.Cqrs.Queries.QRCodes;
using Lishl.GraphQL.Cqrs.Queries.Users;
using Lishl.GraphQL.GraphQL.Types.Link;
using Lishl.GraphQL.GraphQL.Types.QRCode;
using Lishl.GraphQL.GraphQL.Types.User;
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
            
            FieldAsync<LinkType>("linkByShort", 
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "shortUrl", Description = "short url of the link" }),
                resolve: async context =>
                {
                    try
                    {
                        var shortUrl = context.GetArgument<string>("shortUrl");
                        return await mediator.Send(new GetLinkByShortUrlQuery { ShortUrl = shortUrl });
                    }
                    catch (ExecutionError e)
                    {
                        context.Errors.Add(new ExecutionError(e.Message));
                        return null;
                    }
                });
            
            FieldAsync<QRCodeType>("qrCode", 
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "Id of the qr code" }),
                resolve: async context =>
                {
                    try
                    {
                        var qrCodeId = context.GetArgument<Guid>("id");
                        return await mediator.Send(new GetQRCodeByIdQuery { QRCodeId = qrCodeId });
                    }
                    catch (ExecutionError e)
                    {
                        context.Errors.Add(new ExecutionError(e.Message));
                        return null;
                    }
                });

            Field<ListGraphType<UserType>>("users", resolve: _ => mediator.Send(new GetUsersQuery()));
            Field<ListGraphType<LinkType>>("links", resolve: _ => mediator.Send(new GetLinksQuery()));
            Field<ListGraphType<QRCodeType>>("qrCodes", resolve: _ => mediator.Send(new GetQRCodesQuery()));
        }
    }
}