using GraphQL.Types;
using Lishl.GraphQL.Cqrs.Queries.Links;
using Lishl.GraphQL.Cqrs.Queries.QRCodes;
using Lishl.GraphQL.GraphQL.Types.Link;
using Lishl.GraphQL.GraphQL.Types.QRCode;
using MediatR;

namespace Lishl.GraphQL.GraphQL.Types.User
{
    public sealed class UserType : ObjectGraphType<Core.Models.User>
    {
        public UserType(IMediator mediator)
        {
            Name = "User";
            Description = "User details";
            
            Field(u => u.Id).Description("Identifier of the user");
            Field(u => u.Username).Description("Username of the user");
            Field(u => u.Email).Description("Email of the user");
            Field<ListGraphType<UserRoleType>>("roles","Roles of the user", resolve: u => u.Source.Roles);
            
            FieldAsync<ListGraphType<LinkType>>("links", "Links of the user", resolve: async context => await mediator.Send(new GetLinksByUserIdQuery
            {
                UserId = context.Source.Id
            }));
            
            FieldAsync<ListGraphType<QRCodeType>>("qrCodes", "QR codes of the user", resolve: async context => await mediator.Send(new GetQRCodesByUserIdQuery
            {
                UserId = context.Source.Id
            }));
        }
    }
}