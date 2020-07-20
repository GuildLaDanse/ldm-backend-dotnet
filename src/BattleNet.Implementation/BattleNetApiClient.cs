using LaDanse.External.BattleNet.Abstractions;
using LaDanse.External.BattleNet.Abstractions.ProfileApi;
using LaDanse.External.BattleNet.Implementation.ProfileApi;
using Serilog;

namespace LaDanse.External.BattleNet.Implementation
{
    public class BattleNetApiClient : IBattleNetApiClient
    {
        private readonly ILogger _logger = Log.ForContext<BattleNetApiClient>();

        public ApiRegion ApiRegion { get; }

        public string AccessToken { get; }

        public int ExpiresIn { get; }

        public BattleNetApiClient(ApiRegion apiRegion, string accessToken, int expiresIn)
        {
            ApiRegion = apiRegion;
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
        }

        public IGuildApi GuildApi()
        {
            return new GuildApi(this);
        }
    }
}