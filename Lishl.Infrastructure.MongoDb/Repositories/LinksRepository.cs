using System;
using System.Threading.Tasks;
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

        public Task<Link> GetByShortUrlAsync(string shortUrl)
        {
            return _сollection.Find(link => link.ShortUrl.Equals(shortUrl)).FirstOrDefaultAsync();
        }
    }
}