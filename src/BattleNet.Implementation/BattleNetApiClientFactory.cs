using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using LaDanse.External.BattleNet.Abstractions;
using Serilog;

namespace LaDanse.External.BattleNet.Implementation
{
    public class BattleNetApiClientFactory : IBattleNetApiClientFactory
    {
        private readonly ILogger _logger = Log.ForContext<BattleNetApiClientFactory>();
        
        public async Task<IBattleNetApiClient> CreateClientAsync(ApiRegion apiRegion, string clientId, string clientSecret)
        {
            try
            {
                var oAuthToken = await "https://eu.battle.net/oauth/token"
                    .SetQueryParams(new
                    {
                        grant_type = "client_credentials"
                    })
                    .WithBasicAuth(
                        clientId, 
                        clientSecret)
                    .GetAsync()
                    .ReceiveJson<OAuthTokenResponse>();
                
                return new BattleNetApiClient(
                    apiRegion,
                    oAuthToken.AccessToken,
                    oAuthToken.ExpiresIn);
            }
            catch (FlurlHttpException e)
            {
                _logger.Error(e, "Could not get access token");
                
                throw new CannotCreateClientException("Could not get access token", e);
            }
        }
    }
}
