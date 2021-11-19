using Lishl.Core.Models;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Queries
{
    public record GetUserByEmailQuery : IRequest<User>
    {
        public string Email { get; set; }
    }
}