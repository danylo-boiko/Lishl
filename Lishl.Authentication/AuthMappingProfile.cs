using AutoMapper;
using Lishl.Core.Enums;
using Lishl.Core.Models;
using Lishl.Core.Requests;
using Lishl.Core.Requests.Auth;
using Lishl.Users.Api.Cqrs.Commands;
using Microsoft.AspNetCore.Identity;

namespace Lishl.Authentication
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            var passwordHasher = new PasswordHasher<User>();

            CreateMap<RegisterRequest, CreateUserCommand>().ForMember(u => u.HashedPassword, cu =>
            {
                cu.MapFrom(c => passwordHasher.HashPassword(new User(), c.Password));
            }).ForMember(u => u.Roles, cu =>
            {
                cu.MapFrom(_ => new List<UserRole>(new [] { UserRole.Default }));
            });
        }
    }
}