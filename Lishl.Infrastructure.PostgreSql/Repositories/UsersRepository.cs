using System;
using Lishl.Core.Models;
using Lishl.Core.Repositories;

namespace Lishl.Infrastructure.PostgreSql.Repositories
{
    public class UsersRepository : PostgreSqlGenericRepository<User, Guid>, IUsersRepository
    {
        public UsersRepository(PostgreSqlDbContext context) : base(context)
        {
        }
    }
}