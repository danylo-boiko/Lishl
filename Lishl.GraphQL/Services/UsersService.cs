﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Lishl.Core;
using Lishl.Core.GraphQL.Requests;
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

        public async Task<User> GetAsync(Guid userId)
        {
            var response = await _client.GetAsync($"api/v1/users/{userId}");
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<User>();
            }

            return null;
        }

        public async Task<User> CreateAsync(CreateUserRequest createUserRequest)
        {
            var response = await _client.PostAsJsonAsync("api/v1/users", createUserRequest);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<User>();
        }

        public async Task<User> UpdateAsync(Guid userId, UpdateUserRequest updateUserRequest)
        {
            var response = await _client.PutAsJsonAsync($"api/v1/users/{userId}", updateUserRequest);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<User>();
        }

        public async Task DeleteAsync(Guid userId)
        {
            var response = await _client.DeleteAsync($"api/v1/users/{userId}");
            response.EnsureSuccessStatusCode();
        }
    }
}