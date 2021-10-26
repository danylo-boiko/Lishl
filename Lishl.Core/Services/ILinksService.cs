using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lishl.Core.Models;

namespace Lishl.Core.Services
{
    public interface ILinksService
    {
        public Task<IEnumerable<Link>> Get();
        public Task<IEnumerable<Link>> GetLinksByUserId(Guid userId);
        public Task<Link> Get(Guid linkId);
    }
}