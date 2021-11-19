using GraphQL.Types;
using Lishl.Core.Requests;

namespace Lishl.GraphQL.GraphQL.Types
{
    public sealed class UpdateQRCodeType : InputObjectGraphType<UpdateQRCodeRequest>
    {
        public UpdateQRCodeType()
        {
            Field(l => l.UserId).Description("Id of stored user");
            Field(l => l.Url).Description("Url");
        }
    }
}