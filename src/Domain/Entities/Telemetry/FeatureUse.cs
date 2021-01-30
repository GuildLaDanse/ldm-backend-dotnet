using System;
using LaDanse.Domain.Entities.Identity;
using LaDanse.Domain.Entities.Shared;

namespace LaDanse.Domain.Entities.Telemetry
{
    public partial class FeatureUse : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public DateTime UsedOn { get; set; }
        public string Feature { get; set; }
        public string RawData { get; set; }

        public Guid? UsedById { get; set; }
        public virtual User UsedBy { get; set; }
    }
}
