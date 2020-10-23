using System;

namespace LaDanse.Application.Events.Models
{
    public class CommentGroupReference
    {
        public CommentGroupReference(string id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }

        public string Id { get; }
    }
}