using System;
using LaDanse.Domain.Entities.Identity;
using LaDanse.Domain.Entities.Shared;

namespace LaDanse.Domain.Entities.Telemetry
{
    public partial class Feedback : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public DateTime PostedOn { get; set; }
        public string Content { get; set; }

        public Guid PostedById { get; set; }
        public virtual User PostedBy { get; set; }
    }
}
