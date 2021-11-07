using GraphQL.Types;
using Lishl.Core.Requests;

namespace Lishl.GraphQL.GraphQL.Types
{
    public sealed class CreateUserType : InputObjectGraphType<CreateUserRequest>
    {
        public CreateUserType()
        {
            Field(u => u.Username).Description("Username of the user");
            Field(u => u.Email).Description("Email of the user");
            Field(u => u.Password).Description("Password of the user");
            Field<ListGraphType<UserRoleType>>("roles","Roles of the user", resolve: u => u.Source.Roles);
        }
    }
}