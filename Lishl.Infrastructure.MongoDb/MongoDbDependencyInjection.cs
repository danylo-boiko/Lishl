using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lishl.Infrastructure.MongoDb
{
    public static class MongoDbDependencyInjection
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, string connection)
        {
            services.AddScoped<IMongoClient>(_ =>

                new MongoClient(new MongoClientSettings()
                {
                    GuidRepresentation = GuidRepresentation.Standard,
                    Server = new MongoServerAddress(connection)
                })
            );

            return services;
        } 
    }
}