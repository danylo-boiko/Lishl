using GraphQL.Server;
using GraphQL.Types;
using Lishl.GraphQL.GraphQL.Mutations;
using Lishl.GraphQL.GraphQL.Queries;
using Lishl.GraphQL.GraphQL.Schemas;
using Lishl.GraphQL.GraphQL.Types;
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
            services.AddScoped<LishlQuery>();
            services.AddScoped<LishlMutation>();

            services.AddScoped<UserType>();
            services.AddScoped<LinkType>();
            services.AddScoped<LinkFollowType>();

            services.AddScoped<CreateUserType>();
            services.AddScoped<CreateLinkType>();
            services.AddScoped<CreateLinkFollowType>();

            services.AddScoped<ISchema, LishlSchema>();
            
            services.AddGraphQL(opt =>
            {
                opt.EnableMetrics = true;
            }).AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true).AddSystemTextJson();
            
            services.AddMediatR(typeof(Startup));
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyOrigin().AllowAnyHeader());
            app.UseGraphQL<ISchema>();
            app.UseGraphQLPlayground();
            app.UseRouting();
        }
    }
}