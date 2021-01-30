using System;
using LaDanse.Domain.Entities.GameData.Core;
using LaDanse.Domain.Entities.Shared;

namespace LaDanse.Domain.Entities.GameData.Characters
{
    public partial class GameCharacterVersion : IBaseEntity<Guid>, ITimeVersionedEntity
    {
        public Guid Id { get; set; }
        
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }
        
        public short Level { get; set; }
        
        public Guid GameCharacterId { get; set; }
        public virtual GameCharacter GameCharacter { get; set; }
        
        public Guid GameClassId { get; set; }
        public virtual GameClass GameClass { get; set; }
        
        public Guid GameRaceId { get; set; }
        public virtual GameRace GameRace { get; set; }
    }
}
