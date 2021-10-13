using System;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.Users.Api.Cqrs.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}