using System;
using System.Threading.Tasks;
using Lishl.Core.Models;

namespace Lishl.Core.Repositories
{
    public interface ILinksRepository : IGenericRepository<Link, Guid>
    {
        public Task<Link> GetByShortUrlAsync(string shortUrl);
    }
}