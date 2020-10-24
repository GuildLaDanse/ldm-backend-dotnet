using System;
using System.Collections.Generic;

namespace LaDanse.Application.Events.Models
{
    public class SignUp
    {
        public Guid Id { get; set; }
        
        public UserReference UserRef { get; set; }
        
        public string Type { get; set; }
        
        public IEnumerable<string> Roles { get; set; }
    }
}