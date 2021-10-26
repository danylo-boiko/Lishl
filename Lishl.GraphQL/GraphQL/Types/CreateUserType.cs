using GraphQL.Types;
using Lishl.Core.Models;

namespace Lishl.GraphQL.GraphQL.Types
{
    public sealed class CreateUserType : InputObjectGraphType<User>
    {
        public CreateUserType()
        {
            Field(u => u.Username).Description("Username of the user");
            Field(u => u.Email).Description("Email of the user");
            Field(u => u.HashedPassword).Description("Password of the user");
            Field(u => u.Roles).Description("Roles of the user");
        }
    }
}