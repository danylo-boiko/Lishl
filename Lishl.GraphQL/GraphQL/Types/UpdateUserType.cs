using GraphQL.Types;
using Lishl.Core.Requests;

namespace Lishl.GraphQL.GraphQL.Types
{
    public sealed class UpdateUserType: InputObjectGraphType<UpdateUserRequest>
    {
        public UpdateUserType()
        {
            Field(u => u.Username, true).Description("Username of the user");
            Field(u => u.Email, true).Description("Email of the user");
            Field(u => u.Password, true).Description("Password of the user");
            Field<ListGraphType<UserRoleType>>("roles","Roles of the user", resolve: u => u.Source.Roles);
        }
    }
}