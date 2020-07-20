using System;
using LaDanse.Domain.Entities.GameData.Characters;

namespace LaDanse.Domain.Entities.GameData.Sync.Guild
{
    public partial class GameGuildSync : GameCharacterSource
    {
        public Guid GameGuildId { get; set; }
        public virtual GameGuild GameGuild { get; set; }
    }
}