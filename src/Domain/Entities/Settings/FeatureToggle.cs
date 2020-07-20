using System;
using LaDanse.Domain.Entities.Identity;
using LaDanse.Domain.Shared;

namespace LaDanse.Domain.Entities.Settings
{
    public partial class FeatureToggle : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Feature { get; set; }
        public bool Toggle { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}