using System;
using LaDanse.Domain.Entities.Identity;
using LaDanse.Domain.Shared;

namespace LaDanse.Domain.Entities.Forums
{
    public partial class Forum : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? LastPostDate { get; set; }

        public Guid? LastPostPosterId { get; set; }
        public virtual User LastPostPoster { get; set; }

        public Guid? LastPostTopicId { get; set; }
        public virtual Topic LastPostTopic { get; set; }
    }
}