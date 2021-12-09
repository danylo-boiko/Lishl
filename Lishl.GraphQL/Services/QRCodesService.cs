using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GraphQL;
using Lishl.Core;
using Lishl.Core.Models;
using Lishl.Core.Requests.QRCode;
using Lishl.Core.Services;

namespace Lishl.GraphQL.Services
{
    public class QRCodesService : IQRCodesService
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "api/v1/qrcodes";

        public QRCodesService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(HttpClientNames.QRCodesClient);
        }

        public Task<IEnumerable<QRCode>> GetAsync()
        {
            return _client.GetFromJsonAsync<IEnumerable<QRCode>>(BaseUrl);
        }

        public async Task<IEnumerable<QRCode>> GetQRCodesByUserIdAsync(Guid userId)
        {
            var response = await _client.GetAsync($"{BaseUrl}/userId/{userId}");
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<QRCode>>();
            }
            
            throw new ExecutionError(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<QRCode> GetAsync(Guid qrCodeId)
        {
            var response = await _client.GetAsync($"{BaseUrl}/{qrCodeId}");
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<QRCode>();
            }
            
            throw new ExecutionError(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<QRCode> CreateAsync(CreateQRCodeRequest createQRCodeRequest)
        {
            var response = await _client.PostAsJsonAsync(BaseUrl, createQRCodeRequest);
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<QRCode>();
            }
            
            throw new ExecutionError(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<QRCode> UpdateAsync(Guid qrCodeId, UpdateQRCodeRequest updateQRCodeRequest)
        {
            var response = await _client.PutAsJsonAsync($"{BaseUrl}/{qrCodeId}", updateQRCodeRequest);
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<QRCode>();
            }
            
            throw new ExecutionError(response.Content.ReadAsStringAsync().Result);
        }

        public async Task DeleteAsync(Guid qrCodeId)
        {
            var response = await _client.DeleteAsync($"{BaseUrl}/{qrCodeId}");
            response.EnsureSuccessStatusCode();
        }
    }
}