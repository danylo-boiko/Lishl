using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lishl.Core.Models;

namespace Lishl.Core.Services
{
    public interface ILinksService
    {
        public Task<IEnumerable<Link>> GetAsync();
        public Task<IEnumerable<Link>> GetLinksByUserIdAsync(Guid userId);
        public Task<Link> GetAsync(Guid linkId);
    }
}