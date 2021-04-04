using System;
using LaDanse.Application.Events.Models;
using MediatR;

namespace LaDanse.Application.Events.Queries.GetEvent
{
    public record GetEventQuery : IRequest<Event>
    {
        public Guid EventId { get; init; }
    }
}