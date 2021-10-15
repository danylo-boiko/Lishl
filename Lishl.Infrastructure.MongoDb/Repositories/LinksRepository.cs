using System;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MongoDB.Driver;

namespace Lishl.Infrastructure.MongoDb.Repositories
{
    public class LinksRepository : MongoDbGenericRepository<Link, Guid>, ILinksRepository
    {
        public LinksRepository(IMongoDatabase mongoDatabase)
        {
            _сollection = mongoDatabase.GetCollection<Link>("Links");
        }
    }
}