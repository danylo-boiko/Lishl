using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lishl.Core;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using MongoDB.Driver;

namespace Lishl.Infrastructure.MongoDb.Repositories
{
    public abstract class MongoDbGenericRepository <T1, T2> : IGenericRepository<T1, T2> where T1: class, IBaseModel<T2>
    {
        protected IMongoCollection<T1> _сollection;
        
        public Task<T1> GetAsync(T2 id)
        {
            return _сollection.Find(obj => obj.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public Task<List<T1>> GetAsync(PaginationFilter paginationFilter)
        {
            return _сollection.Find(_ => true).Skip(paginationFilter.Offset).Limit(paginationFilter.Limit).ToListAsync();
        }

        public Task<List<T1>> GetAsync(Expression<Func<T1, bool>> predicate, PaginationFilter paginationFilter)
        {
            return _сollection.Find(predicate).Skip(paginationFilter.Offset).Limit(paginationFilter.Limit).ToListAsync();
        }

        public Task<T1> CreateAsync(T1 entity)
        {
            _сollection.InsertOne(entity);
            return _сollection.Find(obj => obj.Id.Equals(entity.Id)).FirstOrDefaultAsync();
        }

        public Task UpdateAsync(T1 entity)
        {
            return _сollection.ReplaceOneAsync(obj => obj.Id.Equals(entity.Id), entity);
        }

        public Task DeleteAsync(T2 id)
        {
            return _сollection.DeleteOneAsync(obj => obj.Id.Equals(id));
        }
    }
}