using System;

namespace LaDanse.Application.Events.Models
{
    public record CreateEvent
    {
        public string Name { get; init; }
        
        public string Description { get; init; }
        
        public DateTime InviteTime { get; init; }
        
        public DateTime StartTime { get; init; }
        
        public DateTime EndTime { get; init; }
    }
}