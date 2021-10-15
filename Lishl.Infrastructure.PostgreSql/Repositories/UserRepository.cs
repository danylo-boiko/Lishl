using System;
using Lishl.Core.Models;
using Lishl.Core.Repositories;

namespace Lishl.Infrastructure.PostgreSql.Repositories
{
    public class UserRepository : PostgreSqlGenericRepository<User, Guid>, IUserRepository
    {
        public UserRepository(PostgreSqlDbContext context) : base(context)
        {
        }
    }
}