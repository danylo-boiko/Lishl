using System;
using GraphQL.Types;
using Lishl.GraphQL.GraphQL.Mutations;
using Lishl.GraphQL.GraphQL.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Lishl.GraphQL.GraphQL.Schemas
{
    public class LishlSchema : Schema
    {
        public LishlSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<LishlQuery>();
            Mutation = provider.GetRequiredService<LishlMutation>();
        }
    }
}