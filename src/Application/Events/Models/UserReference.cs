using System;

namespace LaDanse.Application.Events.Models
{
    public record UserReference
    {
        public UserReference(Guid userId, string name)
        {
            Id = userId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public Guid Id { get; }
        
        public string Name { get; }
    }
}