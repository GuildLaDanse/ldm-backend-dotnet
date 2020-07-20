using System;
using LaDanse.Domain.Entities.Identity;
using LaDanse.Domain.Shared;

namespace LaDanse.Domain.Entities.Settings
{
    public partial class Setting : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}