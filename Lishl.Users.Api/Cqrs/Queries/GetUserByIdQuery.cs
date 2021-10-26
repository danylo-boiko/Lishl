using System;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Queries
{
    public record GetUserByIdQuery : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}