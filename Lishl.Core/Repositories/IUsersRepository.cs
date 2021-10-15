using System;
using Lishl.Core.Models;

namespace Lishl.Core.Repositories
{
    public interface IUsersRepository : IGenericRepository<User, Guid>
    {
    }
}