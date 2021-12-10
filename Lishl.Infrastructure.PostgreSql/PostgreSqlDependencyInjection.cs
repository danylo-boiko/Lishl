using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lishl.Infrastructure.PostgreSql
{
    public static class PostgreSqlDependencyInjection
    {
        public static IServiceCollection AddPostgreSql(this IServiceCollection services, string connection)
        {
            Console.WriteLine($"Connection string: {connection}");
            
            services.AddDbContext<PostgreSqlDbContext>(opt => 
                opt.UseNpgsql(connection, builder => builder.MigrationsAssembly("Lishl.Users.Api")));
            return services;
        }
    }
}