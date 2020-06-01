using System;
using LaDanse.Domain.Entities.GameData.Characters;
using LaDanse.Domain.Entities.Identity;
using LaDanse.Domain.Shared;

namespace LaDanse.Domain.Entities.CharacterClaims
{
    public partial class GameCharacterClaim : IBaseEntity<Guid>, ITemporalEntity
    {
        public Guid Id { get; set; }

        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid GameCharacterId { get; set; }
        public virtual GameCharacter GameCharacter { get; set; }
    }
}
