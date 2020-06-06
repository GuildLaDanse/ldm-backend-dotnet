using LaDanse.External.BattleNet.Abstractions.ProfileApi;

namespace LaDanse.External.BattleNet.Abstractions
{
    public interface IBattleNetApiClient
    {
        public ApiRegion ApiRegion { get; }

        IGuildApi GuildApi();
    }
}