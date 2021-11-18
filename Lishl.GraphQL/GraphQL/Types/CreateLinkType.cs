﻿using GraphQL.Types;
using Lishl.Core.Requests;

namespace Lishl.GraphQL.GraphQL.Types
{
    public sealed class CreateLinkType : InputObjectGraphType<CreateLinkRequest>
    {
        public CreateLinkType()
        {
            Field(l => l.UserId).Description("Id of stored user");
            Field(l => l.FullUrl).Description("Full url");
        }
    }
}