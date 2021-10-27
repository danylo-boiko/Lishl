using System;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Commands
{
    public record DeleteLinkCommand : IRequest<Guid>
    {
        public Guid LinkId { get; set; }
    }
}