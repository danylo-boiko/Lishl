using GraphQL.Types;
using Lishl.Core.Enums;
using Lishl.Core.Models;

namespace Lishl.GraphQL.GraphQL.Types
{
    public sealed class UserInputType : InputObjectGraphType<User>
    {
        public UserInputType()
        {
            Field(u => u.Username).Description("Username of the user");
            Field(u => u.Email).Description("Email of the user");
            Field(u => u.HashedPassword).Description("Password of the user");
            Field<ListGraphType<UserRoleType>>("roles","Roles of the user", resolve: u => u.Source.Roles);
        }
    }
}