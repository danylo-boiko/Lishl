using System;
using Lishl.Core.Models;
using MediatR;

namespace Lishl.GraphQL.Cqrs.Queries
{
    public record GetLinkByIdQuery(Guid LinkId): IRequest<Link>;
}