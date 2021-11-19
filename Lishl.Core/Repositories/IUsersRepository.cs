using System;
using System.Threading.Tasks;
using Lishl.Core.Models;

namespace Lishl.Core.Repositories
{
    public interface IUsersRepository : IGenericRepository<User, Guid>
    {
        public Task<User> GetByEmailAsync(string email);
    }
}