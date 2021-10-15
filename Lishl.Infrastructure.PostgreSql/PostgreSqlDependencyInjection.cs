using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lishl.Infrastructure.PostgreSql
{
    public static class PostgreSqlDependencyInjection
    {
        public static IServiceCollection AddPostgreSql(this IServiceCollection services, string connection)
        {
            services.AddDbContext<PostgreSqlDbContext>(opt => opt.UseNpgsql(connection));
            return services;
        }
    }
}