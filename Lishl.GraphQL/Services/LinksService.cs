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
        private const string BaseUrl = "api/v1/links";

        public LinksService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(HttpClientNames.LinksClient);
        }

        public Task<IEnumerable<Link>> GetAsync()
        {
            return _client.GetFromJsonAsync<IEnumerable<Link>>(BaseUrl);
        }

        public async Task<IEnumerable<Link>> GetLinksByUserIdAsync(Guid userId)
        {
            var response = await _client.GetAsync($"{BaseUrl}/userId/{userId}");
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Link>>();
            }
            
            throw new ExecutionError(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<Link> GetAsync(Guid linkId)
        {
            var response = await _client.GetAsync($"{BaseUrl}/{linkId}");
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Link>();
            }
            
            throw new ExecutionError(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<Link> GetAsync(string shortUrl)
        {
            var response = await _client.GetAsync($"{BaseUrl}/short/{shortUrl}");
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Link>();
            }
            
            throw new ExecutionError(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<Link> CreateAsync(CreateLinkRequest createLinkRequest)
        {
            var response = await _client.PostAsJsonAsync(BaseUrl, createLinkRequest);
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Link>();
            }
            
            throw new ExecutionError(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<Link> UpdateAsync(Guid linkId, UpdateLinkRequest updateLinkRequest)
        {
            var response = await _client.PutAsJsonAsync($"{BaseUrl}/{linkId}", updateLinkRequest);
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Link>();
            }
            
            throw new ExecutionError(response.Content.ReadAsStringAsync().Result);
        }

        public async Task DeleteAsync(Guid linkId)
        {
            var response = await _client.DeleteAsync($"{BaseUrl}/{linkId}");
            response.EnsureSuccessStatusCode();
        }
    }
}