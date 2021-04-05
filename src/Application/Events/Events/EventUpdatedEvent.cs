using System;
using LaDanse.Application.Common.Interfaces;

namespace LaDanse.Application.Events.Events
{
    public class EventUpdatedEvent : IIntegrationEvent
    {
        public Guid EventId { get; set; }
        
        public BasicEvent OldEvent { get; init; }
        
        public BasicEvent UpdatedEvent { get; init; }

    }
}