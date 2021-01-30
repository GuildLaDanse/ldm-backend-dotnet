using System;
using LaDanse.Domain.Entities.Shared;

namespace LaDanse.Domain.Entities.GameData.Sync
{
    public partial class GameCharacterSyncSession : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }
        
        public string Log { get; set; }
        
        public Guid GameCharacterSourceId{ get; set; }
        public virtual GameCharacterSource GameCharacterSource { get; set; }
    }
}
