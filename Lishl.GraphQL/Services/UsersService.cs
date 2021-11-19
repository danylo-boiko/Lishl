using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GraphQL;
using Lishl.Core;
using Lishl.Core.Models;
using Lishl.Core.Requests;
using Lishl.Core.Services;

namespace Lishl.GraphQL.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "api/v1/users";
        
        public UsersService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(HttpClientNames.UsersClient);
        }

        public Task<IEnumerable<User>> GetAsync()
        {
            return _client.GetFromJsonAsync<IEnumerable<User>>(BaseUrl);
        }

        public async Task<User> GetAsync(Guid userId)
        {
            var response = await _client.GetAsync($"{BaseUrl}/{userId}");
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<User>();
            }
            
            throw new ExecutionError(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<User> CreateAsync(CreateUserRequest createUserRequest)
        {
            var response = await _client.PostAsJsonAsync(BaseUrl, createUserRequest);
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<User>();
            }
            
            throw new ExecutionError(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<User> UpdateAsync(Guid userId, UpdateUserRequest updateUserRequest)
        {
            var response = await _client.PutAsJsonAsync($"{BaseUrl}/{userId}", updateUserRequest);
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<User>();
            }
            
            throw new ExecutionError(response.Content.ReadAsStringAsync().Result);
        }

        public async Task DeleteAsync(Guid userId)
        {
            var response = await _client.DeleteAsync($"{BaseUrl}/{userId}");
            response.EnsureSuccessStatusCode();
        }
    }
}