using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lishl.Core.Models;

namespace Lishl.Core.Services
{
    public interface IUsersService
    {
        public Task<IEnumerable<User>> GetAsync();
        public Task<User> GetAsync(Guid userId);
    }
}