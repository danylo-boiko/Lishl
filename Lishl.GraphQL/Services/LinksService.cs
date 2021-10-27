using System;
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

        public Task<IEnumerable<Link>> GetLinksByUserIdAsync(Guid userId)
        {
            return _client.GetFromJsonAsync<IEnumerable<Link>>($"api/v1/links/userId/{userId}");
        }

        public async Task<Link> GetAsync(Guid linkId)
        {
            var response = await _client.GetAsync($"api/v1/links/{linkId}");
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Link>();
            }

            return null;
        }

        public async Task<Link> CreateAsync(CreateLinkRequest createLinkRequest)
        {
            var response = await _client.PostAsJsonAsync("api/v1/links", createLinkRequest);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Link>();
        }

        public async Task UpdateAsync(UpdateLinkRequest updateLinkRequest)
        {
            var response = await _client.PutAsJsonAsync("api/v1/links", updateLinkRequest);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Guid linkId)
        {
            var response = await _client.DeleteAsync($"api/v1/links/{linkId}");
            response.EnsureSuccessStatusCode();
        }
    }
}