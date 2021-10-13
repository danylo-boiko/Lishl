using System;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lishl.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PostgreSqlDbContext _context;

        public UserRepository(PostgreSqlDbContext context)
        {
            _context = context;
        }

        public Task<User> GetById(Guid userId)
        {
            return _context.Users.FirstOrDefaultAsync(user => user.Id == userId);
        }

        public Task Create(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            
            _context.Users.Add(user);
            return _context.SaveChangesAsync();
        }

        public Task Update(User user)
        {
            _context.Users.Update(user);
            return _context.SaveChangesAsync();
        }

        public Task Delete(Guid userId)
        {
            var user = _context.Users.Find(userId);
            _context.Users.Remove(user);
            return _context.SaveChangesAsync();
        }
    }
}