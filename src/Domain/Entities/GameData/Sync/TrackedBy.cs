using System;
using LaDanse.Domain.Entities.GameData.Characters;
using LaDanse.Domain.Entities.Shared;

namespace LaDanse.Domain.Entities.GameData.Sync
{
    public partial class TrackedBy : IBaseEntity<Guid>, ITimeVersionedEntity
    {
        public Guid Id { get; set; }

        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }

        public Guid GameCharacterId { get; set; }
        public virtual GameCharacter GameCharacter { get; set; }
        
        public Guid GameCharacterSourceId { get; set; }
        public virtual GameCharacterSource GameCharacterSource { get; set; }
    }
}
