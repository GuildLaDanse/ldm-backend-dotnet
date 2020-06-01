using System;
using LaDanse.Domain.Shared;

namespace LaDanse.Domain.Entities.GameData.Characters
{
    public partial class InGameGuild : ITemporalEntity, IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }

        public Guid GameCharacterId { get; set; }
        public virtual GameCharacter GameCharacter { get; set; }
        
        public Guid GameGuildId { get; set; }
        public virtual GameGuild GameGuild { get; set; }
        
    }
}
