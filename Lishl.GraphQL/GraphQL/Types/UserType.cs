﻿using GraphQL.Types;
using Lishl.Core.Enums;
using Lishl.Core.Models;
using Lishl.GraphQL.Cqrs.Queries;
using MediatR;

namespace Lishl.GraphQL.GraphQL.Types
{
    public sealed class UserType : ObjectGraphType<User>
    {
        public UserType(IMediator mediator)
        {
            Name = "User";
            Description = "User details";
            
            Field(u => u.Id).Description("Identifier of the user");
            Field(u => u.Username).Description("Username of the user");
            Field(u => u.Email).Description("Email of the user");
            Field(u => u.HashedPassword).Description("Hashed password of the user");
            Field<ListGraphType<UserRoleType>>("roles","Roles of the user", resolve: u => u.Source.Roles);
            
            Field<ListGraphType<LinkType>>("links", "Links of the user", resolve: context => mediator.Send(new GetLinksByUserIdQuery{UserId = context.Source.Id }));
        }
    }
}