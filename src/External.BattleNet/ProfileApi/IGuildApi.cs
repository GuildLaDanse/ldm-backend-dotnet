using System.Threading.Tasks;
using GuildRoster = LaDanse.External.BattleNet.Abstractions.Models.GuildRoster;
using GuildInfo = LaDanse.External.BattleNet.Abstractions.Models.GuildInfo;

namespace LaDanse.External.BattleNet.Abstractions.ProfileApi
{
    public interface IGuildApi
    {
        Task<GuildInfo.Guild> GuildAsync(string realmSlug, string nameSlug);

        Task<GuildRoster.Roster> GuildRosterAsync(string realmSlug, string nameSlug);
    }
}
