using Lishl.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Lishl.Infrastructure.PostgreSql
{
    public class PostgreSqlDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> opt) : base(opt)
        {
        }
    }
}