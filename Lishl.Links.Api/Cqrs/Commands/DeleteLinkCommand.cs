using System;
using MediatR;

namespace Lishl.Links.Api.Cqrs.Commands
{
    public class DeleteLinkCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}