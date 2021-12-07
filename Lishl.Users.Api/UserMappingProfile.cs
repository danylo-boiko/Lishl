using AutoMapper;
using Lishl.Core.Models;
using Lishl.Core.Requests;
using Lishl.Users.Api.Cqrs.Commands;
using Lishl.Users.Api.Responses;
using Microsoft.AspNetCore.Identity;

namespace Lishl.Users.Api
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            var passwordHasher = new PasswordHasher<User>();
            
            CreateMap<User, UserResponse>();
            
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            
            CreateMap<CreateUserRequest, CreateUserCommand>().ForMember(u => u.HashedPassword, cu =>
            {
                cu.MapFrom(c => passwordHasher.HashPassword(new User(), c.Password));
            });
            CreateMap<UpdateUserRequest, UpdateUserCommand>().ForMember(u => u.HashedPassword, cu =>
            {
                cu.MapFrom(c => passwordHasher.HashPassword(new User(), c.Password));
            });
        }
    }
}