using GraphQL.Types;
using Lishl.GraphQL.Cqrs.Queries.Users;
using Lishl.GraphQL.GraphQL.Types.User;
using MediatR;

namespace Lishl.GraphQL.GraphQL.Types.QRCode
{
    public sealed class QRCodeType : ObjectGraphType<Core.Models.QRCode>
    {
        public QRCodeType(IMediator mediator)
        {
            Name = "QRCode";
            Description = "Created QRCode";

            Field(l => l.Id).Description("Identifier of the link");
            Field(l => l.Url).Description("Url");
            Field("qrCodeBitmap",l => l.QRCodeBitmap).Description("Bitmap of the url");

            FieldAsync<UserType>("user", "User details", resolve: async content => await mediator.Send(new GetUserByIdQuery
            {
                UserId = content.Source.UserId
            }));
        }
    }
}