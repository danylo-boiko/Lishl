using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lishl.Core.Models;
using Lishl.Core.Requests;

namespace Lishl.Core.Services
{
    public interface IQRCodesService
    {
        public Task<IEnumerable<QRCode>> GetAsync();
        public Task<IEnumerable<QRCode>> GetQRCodesByUserIdAsync(Guid userId);
        public Task<QRCode> GetAsync(Guid qrCodeId);
        public Task<QRCode> CreateAsync(CreateQRCodeRequest createQRCodeRequest);
        public Task<QRCode> UpdateAsync(Guid qrCodeId, UpdateQRCodeRequest updateQRCodeRequest);
        public Task DeleteAsync(Guid qrCodeId);
    }
}