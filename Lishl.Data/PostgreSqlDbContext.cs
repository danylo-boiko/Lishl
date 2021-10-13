using Lishl.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Lishl.Data
{
    public class PostgreSqlDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> opt): base(opt)
        {
        }
    }
}