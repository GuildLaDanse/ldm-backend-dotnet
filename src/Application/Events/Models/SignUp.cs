using System;
using System.Collections.Generic;

namespace LaDanse.Application.Events.Models
{
    public record SignUp
    {
        public Guid Id { get; init; }
        
        public UserReference UserRef { get; init; }
        
        public string Type { get; init; }
        
        public IEnumerable<string> Roles { get; init; }
    }
}