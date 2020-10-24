using System;
using System.Collections.Generic;

namespace LaDanse.Application.Events.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public UserReference OrganiserRef { get; set; }

        public DateTime InviteTime { get; set; }
        
        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }
        
        public string State { get; set; }
        
        public CommentGroupReference CommentGroupRef { get; set; }
        
        public IEnumerable<SignUp> SignUps { get; set; }
    }
}