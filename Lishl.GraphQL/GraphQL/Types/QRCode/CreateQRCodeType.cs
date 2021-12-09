using GraphQL.Types;
using Lishl.Core.Requests.QRCode;

namespace Lishl.GraphQL.GraphQL.Types.QRCode
{
    public sealed class CreateQRCodeType : InputObjectGraphType<CreateQRCodeRequest>
    {
        public CreateQRCodeType()
        {
            Field(l => l.UserId).Description("Id of stored user");
            Field(l => l.Url).Description("Url");
        }
    }
}