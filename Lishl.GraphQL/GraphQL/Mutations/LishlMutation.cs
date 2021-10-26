using System;
using GraphQL;
using GraphQL.Types;
using Lishl.Core.Models;
using Lishl.GraphQL.GraphQL.Types;

namespace Lishl.GraphQL.GraphQL.Mutations
{
    public class LishlMutation : ObjectGraphType
    {
        public LishlMutation()
        {
            Name = "Mutation";

            Field<UserType>("createUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CreateUserType>> { Name = "user" }),
                resolve: context =>
                {
                    var user = context.GetArgument<User>("user");
                    throw new NotImplementedException();
                });
        }
    }
}