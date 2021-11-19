using System;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lishl.Infrastructure.PostgreSql.Repositories
{
    public class UsersRepository : PostgreSqlGenericRepository<User, Guid>, IUsersRepository
    {
        private readonly PostgreSqlDbContext _context;
        
        public UsersRepository(PostgreSqlDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return _context.Users.FirstOrDefaultAsync(user => user.Email.Equals(email));
        }
    }
}