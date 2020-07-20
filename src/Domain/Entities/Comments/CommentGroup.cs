using System;
using LaDanse.Domain.Shared;

namespace LaDanse.Domain.Entities.Comments
{
    public partial class CommentGroup : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime PostDate { get; set; }
    }
}