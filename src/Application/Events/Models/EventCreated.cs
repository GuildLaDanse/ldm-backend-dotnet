using System;

namespace LaDanse.Application.Events.Models
{
    public record EventCreated
    {
        public Guid EventId { get; init; }
    }
}