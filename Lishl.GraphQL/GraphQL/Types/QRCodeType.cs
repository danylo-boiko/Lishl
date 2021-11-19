using GraphQL.Types;
using Lishl.Core.Models;
using Lishl.GraphQL.Cqrs.Queries;
using MediatR;

namespace Lishl.GraphQL.GraphQL.Types
{
    public sealed class QRCodeType : ObjectGraphType<QRCode>
    {
        public QRCodeType(IMediator mediator)
        {
            Name = "QRCode";
            Description = "Created QRCode";

            Field(l => l.Id).Description("Identifier of the link");
            Field(l => l.Url).Description("Url");
            Field(l => l.QRCodeBitmap).Description("Bitmap of the url");

            FieldAsync<UserType>("user", "User details", resolve: async content => await mediator.Send(new GetUserByIdQuery
            {
                UserId = content.Source.UserId
            }));
        }
    }
}