using System.Collections.Generic;
using LaDanse.Domain.Entities.GameData.Characters;
using LaDanse.External.BattleNet.Abstractions.Models.GuildRoster;
using MediatR;

namespace LaDanse.Application.GameData.Sync.GuildSync.Activities.CalculateSyncActions
{
    public class CalculateSyncActions : IRequest<SyncActions>
    {
        public Roster BattleNetGuildRoster { get; set; }

        public List<GameCharacterVersion> GameCharacterVersions { get; set; }
    }
}