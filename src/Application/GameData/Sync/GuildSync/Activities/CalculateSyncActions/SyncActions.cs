using System.Collections.Generic;
using LaDanse.Domain.Entities.GameData.Characters;
using LaDanse.External.BattleNet.Abstractions.Models.GuildRoster;

namespace LaDanse.Application.GameData.Sync.GuildSync.Activities.CalculateSyncActions
{
    public class SyncActions
    {
        public IEnumerable<GameCharacterVersion> GameCharactersToRemove { get; set; }
        
        public IEnumerable<Member> GameCharactersToAdd { get; set; }
        
        public IEnumerable<UpdateAction> GameCharactersToUpdate { get; set; }
    }
}