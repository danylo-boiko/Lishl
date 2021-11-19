using AutoMapper;
using Lishl.Core.Requests;
using Lishl.GraphQL.Cqrs.Commands;

namespace Lishl.GraphQL
{
    public class GraphQLMappingProfile : Profile
    {
        public GraphQLMappingProfile()
        {
            CreateMap<CreateLinkCommand, CreateLinkRequest>();
            CreateMap<CreateUserCommand, CreateUserRequest>();
            
            CreateMap<UpdateLinkCommand, UpdateLinkRequest>();
            CreateMap<UpdateUserCommand, UpdateUserRequest>();
            
            CreateMap<CreateUserRequest, CreateUserCommand>();
            CreateMap<CreateLinkRequest, CreateLinkCommand>();

            CreateMap<UpdateUserRequest, UpdateUserCommand>();
            CreateMap<UpdateLinkRequest, UpdateLinkCommand>();
        }
    }
}