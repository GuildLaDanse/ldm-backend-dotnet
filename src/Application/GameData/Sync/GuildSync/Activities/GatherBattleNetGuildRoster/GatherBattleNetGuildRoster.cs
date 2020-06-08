using LaDanse.External.BattleNet.Abstractions.Models.GuildRoster;
using MediatR;

namespace LaDanse.Application.GameData.Sync.GuildSync.Activities.GatherBattleNetGuildRoster
{
    public class GatherBattleNetGuildRoster : IRequest<Roster>
    {
        public string RealmSlug { get; set; }
        public string GuildSlug { get; set; }
    }
}