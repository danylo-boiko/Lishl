using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Requests;

namespace Lishl.Core.Services
{
    public interface ILinksService
    {
        public Task<IEnumerable<Link>> GetAsync();
        public Task<IEnumerable<Link>> GetLinksByUserIdAsync(Guid userId);
        public Task<Link> GetAsync(Guid linkId);
        public Task<Link> GetAsync(string shortUrl);
        public Task<Link> CreateAsync(CreateLinkRequest createLinkRequest);
        public Task<Link> UpdateAsync(Guid linkId, UpdateLinkRequest updateLinkRequest);
        public Task DeleteAsync(Guid linkId);
    }
}