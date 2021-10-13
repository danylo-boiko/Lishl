using AutoMapper;
using Lishl.Core.Models;
using Lishl.Users.Api.Requests;
using Lishl.Users.Api.Responses;

namespace Lishl.Users.Api
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
        }
    }
}