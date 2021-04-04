using System;
using System.Collections.Generic;

namespace LaDanse.Application.Events.Models
{
    public record Event
    {
        public Guid Id { get; init; }
        
        public string Name { get; init; }
        
        public string Description { get; init; }
        
        public UserReference OrganiserRef { get; init; }

        public DateTime InviteTime { get; init; }
        
        public DateTime StartTime { get; init; }
        
        public DateTime EndTime { get; init; }
        
        public string State { get; init; }
        
        public CommentGroupReference CommentGroupRef { get; init; }
        
        public IEnumerable<SignUp> SignUps { get; init; }
    }
}