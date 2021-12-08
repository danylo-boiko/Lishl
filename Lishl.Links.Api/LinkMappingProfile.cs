using AutoMapper;
using Lishl.Core.Models;
using Lishl.Core.Requests;
using Lishl.Links.Api.Cqrs.Commands;
using Lishl.Links.Api.Responses;

namespace Lishl.Links.Api
{
    public class LinkMappingProfile : Profile
    {
        public LinkMappingProfile()
        {
            CreateMap<Link, LinkResponse>();
            
            CreateMap<CreateLinkCommand, Link>();
            CreateMap<UpdateLinkCommand, Link>();
            
            CreateMap<CreateLinkRequest, CreateLinkCommand>();
            CreateMap<UpdateLinkRequest, UpdateLinkCommand>();
        }
    }
}