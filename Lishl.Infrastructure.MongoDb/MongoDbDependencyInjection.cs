using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Lishl.Infrastructure.MongoDb
{
    public static class MongoDbDependencyInjection
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, string database, string connection)
        {
            services.AddScoped<IMongoDatabase>( _ => {
                var client = new MongoClient(connection);
                return client.GetDatabase(database); 
            });

            return services;
        } 
    }
}