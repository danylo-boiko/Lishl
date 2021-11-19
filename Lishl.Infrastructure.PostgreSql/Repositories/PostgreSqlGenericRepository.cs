using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lishl.Core;
using Lishl.Core.Enums;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lishl.Infrastructure.PostgreSql.Repositories
{
    public abstract class PostgreSqlGenericRepository <T1, T2> : IGenericRepository<T1, T2> where T1: class, IBaseModel<T2>
    {
        private readonly PostgreSqlDbContext _context;

        public PostgreSqlGenericRepository(PostgreSqlDbContext context)
        {
            _context = context;
        }
        
        public Task<T1> GetAsync(T2 id)
        {
            return _context.Set<T1>().FirstOrDefaultAsync(obj => obj.Id.Equals(id));
        }

        public Task<List<T1>> GetAsync(PaginationFilter paginationFilter)
        {
            if (paginationFilter.Limit == 0)
            {
                return _context.Set<T1>().Skip(paginationFilter.Offset).ToListAsync();
            }
            
            return _context.Set<T1>().Skip(paginationFilter.Offset).Take(paginationFilter.Limit).ToListAsync();
        }

        public Task<List<T1>> GetAsync(Expression<Func<T1, bool>> predicate, PaginationFilter paginationFilter)
        {
            if (paginationFilter.Limit == 0)
            {
                return _context.Set<T1>().Where(predicate).Skip(paginationFilter.Offset).ToListAsync();
            }
            
            return _context.Set<T1>().Where(predicate).Skip(paginationFilter.Offset).Take(paginationFilter.Limit).ToListAsync();
        }

        public Task<T1> CreateAsync(T1 entity)
        {
            _context.Set<T1>().Add(entity);
            _context.SaveChanges();
            return _context.Set<T1>().FirstOrDefaultAsync(obj => obj.Id.Equals(entity.Id));
        }

        public Task UpdateAsync(T1 entity)
        {
            var oldEntity = _context.Set<T1>().Find(entity.Id);

            foreach(var property in typeof(T1).GetProperties())
            {
                object value = property.GetValue(entity);

                if (property.PropertyType == typeof(List<UserRole>))
                {
                    if (value is List<UserRole> { Count: > 0 })
                    {
                        property.SetValue(oldEntity, value);
                    }
                } else if (value != null)
                {
                    property.SetValue(oldEntity, value);
                }
            }
            
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(T2 id)
        {
            var entity = _context.Set<T1>().Find(id);
            _context.Set<T1>().Remove(entity);
            return _context.SaveChangesAsync();
        }
    }
}