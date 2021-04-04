using System;

namespace LaDanse.Application.Events.Models
{
    public record CommentGroupReference
    {
        public CommentGroupReference(Guid commentGroupId)
        {
            Id = commentGroupId;
        }

        public Guid Id { get; }
    }
}