using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Requests;

namespace Lishl.Core.Services
{
    public interface IUsersService
    {
        public Task<IEnumerable<User>> GetAsync();
        public Task<User> GetAsync(Guid userId);
        public Task<User> CreateAsync(CreateUserRequest createUserRequest);
        public Task<User> UpdateAsync(Guid userId, UpdateUserRequest updateUserRequest);
        public Task DeleteAsync(Guid userId);
    }
}