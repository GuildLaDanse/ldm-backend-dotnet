using System;
using LaDanse.Domain.Entities.Identity;
using LaDanse.Domain.Shared;

namespace LaDanse.Domain.Entities.Queues
{
    public partial class NotificationQueueItem : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public string ActivityType { get; set; }
        public DateTime ActivityOn { get; set; }
        public string RawData { get; set; }
        public DateTime? ProcessedOn { get; set; }

        public Guid? ActivityById { get; set; }
        public virtual User ActivityBy { get; set; }
    }
}
