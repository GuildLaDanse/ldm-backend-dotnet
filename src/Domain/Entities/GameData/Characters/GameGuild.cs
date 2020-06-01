using System;
using LaDanse.Domain.Entities.GameData.Core;
using LaDanse.Domain.Shared;

namespace LaDanse.Domain.Entities.GameData.Characters
{
    public partial class GameGuild : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public int GameId { get; set; }

        public Guid GameRealmId { get; set; }
        public virtual GameRealm GameRealm { get; set; }
    }
}
