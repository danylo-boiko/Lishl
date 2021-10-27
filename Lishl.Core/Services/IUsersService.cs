using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lishl.Core.GraphQL.Requests;
using Lishl.Core.Models;

namespace Lishl.Core.Services
{
    public interface IUsersService
    {
        public Task<IEnumerable<User>> GetAsync();
        public Task<User> GetAsync(Guid userId);
        public Task<User> CreateAsync(CreateUserRequest createUserRequest);
        public Task UpdateAsync(UpdateUserRequest updateUserRequest);
        public Task DeleteAsync(Guid userId);
    }
}