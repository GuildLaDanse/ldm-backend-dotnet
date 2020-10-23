using System;

namespace LaDanse.Application.Events.Models
{
    public class UserReference
    {
        public UserReference(string id, string name)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Id { get; }
        
        public string Name { get; }
    }
}