using System;
using System.Threading.Tasks;
using Lishl.Core.Models;

namespace Lishl.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(Guid userId);
        Task Create(User user);
        Task Update(User user);
        Task Delete(Guid userId);
    }
}