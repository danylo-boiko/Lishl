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
    public class LinksService : ILinksService
    {
        private readonly HttpClient _client;
        
        public LinksService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(HttpClientNames.LinksClient);
        }

        public Task<IEnumerable<Link>> GetAsync()
        {
            return _client.GetFromJsonAsync<IEnumerable<Link>>("api/v1/links");
        }

        public async Task<IEnumerable<Link>> GetLinksByUserIdAsync(Guid userId)
        {
            var response = await _client.GetAsync($"api/v1/links/userId/{userId}");
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Link>>();
            }
            
            throw new ExecutionError(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<Link> GetAsync(Guid linkId)
        {
            var response = await _client.GetAsync($"api/v1/links/{linkId}");
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Link>();
            }
            
            throw new ExecutionError(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<Link> CreateAsync(CreateLinkRequest createLinkRequest)
        {
            var response = await _client.PostAsJsonAsync("api/v1/links", createLinkRequest);
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Link>();
            }
            
            throw new ExecutionError(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<Link> UpdateAsync(Guid linkId, UpdateLinkRequest updateLinkRequest)
        {
            var response = await _client.PutAsJsonAsync($"api/v1/links/{linkId}", updateLinkRequest);
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Link>();
            }
            
            throw new ExecutionError(response.Content.ReadAsStringAsync().Result);
        }

        public async Task DeleteAsync(Guid linkId)
        {
            var response = await _client.DeleteAsync($"api/v1/links/{linkId}");
            response.EnsureSuccessStatusCode();
        }
    }
}