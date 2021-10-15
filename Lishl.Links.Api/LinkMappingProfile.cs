using AutoMapper;
using Lishl.Core.Models;
using Lishl.Links.Api.Requests;
using Lishl.Links.Api.Responses;

namespace Lishl.Links.Api
{
    public class LinkMappingProfile : Profile
    {
        public LinkMappingProfile()
        {
            CreateMap<Link, LinkResponse>();
            CreateMap<CreateLinkRequest, Link>();
            CreateMap<UpdateLinkRequest, Link>();
        }
    }
}