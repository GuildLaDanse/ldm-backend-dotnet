using System;
using MediatR;

namespace LaDanse.Application.Events.Commands.UpdateBasicEvent
{
    public record UpdateBasicEventCommand : IRequest
    {
        public Guid EventId { get; init; }
        
        public Models.UpdateBasicEvent UpdateBasicEvent { get; init; }
    }
}