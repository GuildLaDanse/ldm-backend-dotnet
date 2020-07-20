using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using LaDanse.External.BattleNet.Abstractions;
using LaDanse.External.BattleNet.Abstractions.Models.GuildRoster;
using LaDanse.External.BattleNet.Abstractions.ProfileApi;
using Serilog;
using Guild = LaDanse.External.BattleNet.Abstractions.Models.GuildInfo.Guild;

namespace LaDanse.External.BattleNet.Implementation.ProfileApi
{
    public class GuildApi : IGuildApi
    {
        private readonly ILogger _logger = Log.ForContext<GuildApi>();

        private readonly BattleNetApiClient _apiClient;

        public GuildApi(BattleNetApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<Guild> GuildAsync(string realmSlug, string nameSlug)
        {
            return CallApi<Guild>(
                $"/data/wow/guild/{realmSlug}/{nameSlug}",
                "profile-" + _apiClient.ApiRegion.RegionId,
                "en_US"
            );
        }

        public Task<Roster> GuildRosterAsync(string realmSlug, string nameSlug)
        {
            return CallApi<Roster>(
                $"/data/wow/guild/{realmSlug}/{nameSlug}/roster",
                "profile-" + _apiClient.ApiRegion.RegionId,
                "en_US"
            );
        }

        private Task<TResult> CallApi<TResult>(string contextUrl, string @namespace, string locale)
        {
            var fullUrl = $"https://{GetHostName()}{contextUrl}";

            try
            {
                return fullUrl
                    .SetQueryParams(new
                    {
                        @namespace = @namespace,
                        locale = locale
                    })
                    .WithOAuthBearerToken(_apiClient.AccessToken)
                    .GetAsync()
                    .ReceiveJson<TResult>();
            }
            catch (FlurlHttpException e)
            {
                _logger.Error(e, "Could not get access token");

                throw new CannotCreateClientException("Could not get access token", e);
            }
        }

        private string GetHostName()
        {
            return _apiClient.ApiRegion.RegionId + ".api.blizzard.com";
        }
    }
}