using System.Collections.Generic;
using LaDanse.Domain.Entities.GameData.Characters;
using LaDanse.Domain.Entities.GameData.Sync.Guild;

namespace LaDanse.Application.GameData.Sync.GuildSync.Activities.GatherDbGameCharacters
{
    public class SyncedDbGameCharacters
    {
        public List<GameCharacterVersion> GameCharacterVersions { get; set; }

        public GameGuildSync GameGuildSync { get; set; }
    }
}