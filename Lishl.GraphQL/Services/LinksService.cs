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

        public Task<Link> GetAsync(Guid linkId)
        {
            return _client.GetFromJsonAsync<Link>($"api/v1/links/{linkId}");
        }
    }
}