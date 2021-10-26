using System;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Commands
{
    public record DeleteLinkCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}