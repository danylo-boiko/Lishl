using System.Collections.Generic;
using Lishl.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Lishl.Authentication.Core.Attributes
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params UserRole[] roles)
        {
            var roleList = new List<string>();

            foreach (var role in roles)
            {
                roleList.Add(role.ToString());
            }

            Roles = string.Join(",", roleList);
        }
    }
}