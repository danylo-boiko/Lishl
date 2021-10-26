using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lishl.Core.Models;

namespace Lishl.Core.Services
{
    public interface IUsersService
    {
        public Task<IEnumerable<User>> Get();
        public Task<User> Get(Guid userId);
    }
}