using System;
using LaDanse.Domain.Entities.Identity;
using LaDanse.Domain.Entities.Shared;

namespace LaDanse.Domain.Entities.Events
{
    public partial class SignUp : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public SignUpType Type { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
