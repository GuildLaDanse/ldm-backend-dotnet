using System.Threading.Tasks;
using LaDanse.External.BattleNet.Abstractions.Models.GuildRoster;
using Guild = LaDanse.External.BattleNet.Abstractions.Models.GuildInfo.Guild;

namespace LaDanse.External.BattleNet.Abstractions.ProfileApi
{
    public interface IGuildApi
    {
        Task<Guild> GuildAsync(string realmSlug, string nameSlug);

        Task<Roster> GuildRosterAsync(string realmSlug, string nameSlug);
    }
}