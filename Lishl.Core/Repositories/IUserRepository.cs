using System;
using Lishl.Core.Models;

namespace Lishl.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User, Guid>
    {
    }
}