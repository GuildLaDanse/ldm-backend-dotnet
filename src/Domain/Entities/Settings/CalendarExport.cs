using System;
using LaDanse.Domain.Entities.Identity;
using LaDanse.Domain.Shared;

namespace LaDanse.Domain.Entities.Settings
{
    public partial class CalendarExport : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public bool ExportNew { get; set; }
        public bool ExportAbsence { get; set; }
        public string Secret { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}