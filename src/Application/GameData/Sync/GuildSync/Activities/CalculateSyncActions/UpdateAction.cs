using LaDanse.Domain.Entities.GameData.Characters;
using LaDanse.External.BattleNet.Abstractions.Models.GuildRoster;

namespace LaDanse.Application.GameData.Sync.GuildSync.Activities.CalculateSyncActions
{
    public class UpdateAction
    {
        public Member BattleNetGuildMember { get; set; }
        
        public GameCharacterVersion GameCharacterVersion { get; set; }
    }
}