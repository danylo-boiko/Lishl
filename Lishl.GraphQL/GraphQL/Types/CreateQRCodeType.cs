using GraphQL.Types;
using Lishl.Core.Requests;

namespace Lishl.GraphQL.GraphQL.Types
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