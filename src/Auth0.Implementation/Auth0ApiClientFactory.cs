using System.Threading.Tasks;
using Auth0.Abstractions;
using Flurl.Http;
using Serilog;

namespace Auth0.Implementation
{
    public class Auth0ApiClientFactory : IAuth0ApiClientFactory
    {
        private readonly ILogger _logger = Log.ForContext<Auth0ApiClientFactory>();

        public async Task<IAuth0ApiClient> CreateClientAsync(
            string domain,
            string audience,
            string clientId,
            string clientSecret)
        {
            try
            {
                var oAuthToken = await $"https://{domain}/oauth/token"
                    .PostUrlEncodedAsync(new
                    {
                        grant_type = "client_credentials",
                        client_id = clientId,
                        client_secret = clientSecret,
                        audience = audience
                    })
                    .ReceiveJson<OAuthTokenResponse>();

                return new Auth0ApiClient(
                    domain,
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