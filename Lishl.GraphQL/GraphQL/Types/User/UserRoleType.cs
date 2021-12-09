using GraphQL.Types;
using Lishl.Core.Enums;

namespace Lishl.GraphQL.GraphQL.Types.User
{
    public class UserRoleType : EnumerationGraphType<UserRole>
    {
        public UserRoleType()
        {
            Name = "userRole";
            Description = "User access role";
            
            AddValue("default","Default access", UserRole.Default);
            AddValue("moderator","Moderator access", UserRole.Moderator);
            AddValue("admin","Admin access", UserRole.Admin);
        }
    }
}