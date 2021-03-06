using AutoMapper;
using Lishl.Core.Requests.Link;
using Lishl.Core.Requests.QRCode;
using Lishl.Core.Requests.User;
using Lishl.GraphQL.Cqrs.Commands.Links;
using Lishl.GraphQL.Cqrs.Commands.QRCodes;
using Lishl.GraphQL.Cqrs.Commands.Users;

namespace Lishl.GraphQL
{
    public class GraphQLMappingProfile : Profile
    {
        public GraphQLMappingProfile()
        {
            CreateMap<CreateLinkCommand, CreateLinkRequest>();
            CreateMap<CreateUserCommand, CreateUserRequest>();
            CreateMap<CreateQRCodeCommand, CreateQRCodeRequest>();

            CreateMap<UpdateLinkCommand, UpdateLinkRequest>();
            CreateMap<UpdateUserCommand, UpdateUserRequest>();
            CreateMap<UpdateQRCodeCommand, UpdateQRCodeRequest>();

            CreateMap<CreateUserRequest, CreateUserCommand>();
            CreateMap<CreateLinkRequest, CreateLinkCommand>();
            CreateMap<CreateQRCodeRequest, CreateQRCodeCommand>();

            CreateMap<UpdateUserRequest, UpdateUserCommand>();
            CreateMap<UpdateLinkRequest, UpdateLinkCommand>();
            CreateMap<UpdateQRCodeRequest, UpdateQRCodeCommand>();
        }
    }
}