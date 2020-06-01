using System;
using LaDanse.Domain.Entities.Identity;
using LaDanse.Domain.Shared;

namespace LaDanse.Domain.Entities.Forums
{
    public partial class ForumLastVisit : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public DateTime LastVisitDate { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
