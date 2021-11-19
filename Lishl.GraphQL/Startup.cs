using System;
using GraphQL.Server;
using GraphQL.Types;
using Lishl.Core;
using Lishl.Core.Services;
using Lishl.GraphQL.GraphQL.Mutations;
using Lishl.GraphQL.GraphQL.Queries;
using Lishl.GraphQL.GraphQL.Schemas;
using Lishl.GraphQL.GraphQL.Types;
using Lishl.GraphQL.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lishl.GraphQL
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddGraphQL(opt =>
            {
                opt.EnableMetrics = true;
            }).AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true).AddSystemTextJson();
            
            services.AddMediatR(typeof(Startup));
            services.AddCors();
        }
        
    }
}