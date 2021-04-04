using System;
using MediatR;

namespace LaDanse.Application.Events.Commands.CreateEvent
{
    public record CreateEventCommand : IRequest<Guid>
    {
        public Models.CreateEvent CreateEvent { get; init; }
    }
}