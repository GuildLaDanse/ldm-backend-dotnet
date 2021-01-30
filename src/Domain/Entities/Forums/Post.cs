using System;
using LaDanse.Domain.Entities.Identity;
using LaDanse.Domain.Entities.Shared;

namespace LaDanse.Domain.Entities.Forums
{
    public partial class Post : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public DateTime PostDate { get; set; }
        public string Content { get; set; }

        public Guid PosterId { get; set; }
        public virtual User Poster { get; set; }

        public Guid TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
