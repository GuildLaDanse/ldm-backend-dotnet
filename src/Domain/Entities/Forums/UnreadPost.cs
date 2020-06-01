using System;
using LaDanse.Domain.Entities.Identity;
using LaDanse.Domain.Shared;

namespace LaDanse.Domain.Entities.Forums
{
    public partial class UnreadPost : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
