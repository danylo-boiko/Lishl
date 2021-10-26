using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Lishl.Core;
using Lishl.Core.Models;
using Lishl.Core.Services;

namespace Lishl.GraphQL.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _client;
        
        public UsersService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(HttpClientNames.UsersClient);
        }

        public Task<IEnumerable<User>> GetAsync()
        {
            return _client.GetFromJsonAsync<IEnumerable<User>>("api/v1/users");
        }

        public Task<User> GetAsync(Guid userId)
        {
            return _client.GetFromJsonAsync<User>($"api/v1/users/{userId}");
        }
    }
}