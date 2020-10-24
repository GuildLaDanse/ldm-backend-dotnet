using System;

namespace LaDanse.Application.Events.Models
{
    public class CommentGroupReference
    {
        public CommentGroupReference(Guid commentGroupId)
        {
            Id = commentGroupId;
        }

        public Guid Id { get; }
    }
}