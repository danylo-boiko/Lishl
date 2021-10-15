using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lishl.Core.Models;

namespace Lishl.Core.Repositories
{
    public interface IGenericRepository <T1, T2> where T1: class, IBaseModel<T2>
    {
        public Task<T1> GetAsync(T2 id);
        public Task<List<T1>> GetAsync(PaginationFilter paginationFilter);
        public Task<List<T1>> GetAsync(Expression<Func<T1, bool>> predicate, PaginationFilter paginationFilter);
        public Task<T1> CreateAsync(T1 entity);
        public Task UpdateAsync(T1 entity);
        public Task DeleteAsync(T2 id);
    }
}