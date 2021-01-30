using System;
using LaDanse.Domain.Entities.GameData;
using LaDanse.Domain.Entities.Shared;

namespace LaDanse.Domain.Entities.CharacterClaims
{
    public partial class PlaysGameRole : IBaseEntity<Guid>, ITimeVersionedEntity
    {
        public Guid Id { get; set; }

        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }
        
        public GameRole GameRole { get; set; }
        
        public Guid GameCharacterClaimId { get; set; }
        public virtual GameCharacterClaim GameCharacterClaim { get; set; }
    }
}
