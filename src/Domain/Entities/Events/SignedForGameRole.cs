using System;
using LaDanse.Domain.Entities.GameData;
using LaDanse.Domain.Shared;

namespace LaDanse.Domain.Entities.Events
{
    public partial class SignedForGameRole : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public GameRole GameRole { get; set; }

        public Guid SignUpId { get; set; }
        public virtual SignUp SignUp { get; set; }
    }
}