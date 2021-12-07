using AutoMapper;
using Lishl.Core.Models;
using Lishl.Core.Requests;
using Lishl.QRCodes.Api.Cqrs.Commands;
using Lishl.QRCodes.Api.Responses;

namespace Lishl.QRCodes.Api
{
    public class QRCodeMappingProfile : Profile
    {
        public QRCodeMappingProfile()
        {
            CreateMap<QRCode, QRCodeResponse>();
            
            CreateMap<CreateQRCodeCommand, QRCode>();
            CreateMap<UpdateQRCodeCommand, QRCode>();
            
            CreateMap<CreateQRCodeRequest, CreateQRCodeCommand>();
            CreateMap<UpdateQRCodeRequest, UpdateQRCodeCommand>();
        }
    }
}