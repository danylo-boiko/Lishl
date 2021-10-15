using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lishl.Infrastructure.MongoDb
{
    public static class MongoDbDependencyInjection
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, string connection)
        {
            services.AddScoped<IMongoDatabase>(_ => 
                {
                    var client = new MongoClient(connection);
                    return client.GetDatabase("LinksService");
                }
            );

            return services;
        } 
    }
}