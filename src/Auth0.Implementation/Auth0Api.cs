using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Serilog;

namespace Auth0.Implementation
{
    public class Auth0Api
    {
        private readonly ILogger _logger = Log.ForContext<Auth0Api>();

        private readonly Auth0ApiClient _apiClient;

        protected Auth0Api(Auth0ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        protected Task<TResult> CallGetApiAsync<TResult>(string contextUrl, object queryValues)
        {
            var fullUrl = $"https://{_apiClient.Domain}/api/v2{contextUrl}";

            try
            {
                return fullUrl
                    .SetQueryParams(queryValues)
                    .WithOAuthBearerToken(_apiClient.AccessToken)
                    .GetAsync()
                    .ReceiveJson<TResult>();
            }
            catch (FlurlHttpException e)
            {
                _logger.Error(e, $"Could not call {contextUrl}");

                throw;
            }
        }
        
        protected Task CallDeleteApiAsync(string contextUrl, object queryValues)
        {
            var fullUrl = $"https://{_apiClient.Domain}/api/v2{contextUrl}";

            try
            {
                return fullUrl
                    .SetQueryParams(queryValues)
                    .WithOAuthBearerToken(_apiClient.AccessToken)
                    .DeleteAsync();
            }
            catch (FlurlHttpException e)
            {
                _logger.Error(e, $"Could not call {contextUrl}");

                throw;
            }
        }

        protected Task<TResult> CallPostApiAsync<TPost, TResult>(string contextUrl, TPost postObject)
        {
            var fullUrl = $"https://{_apiClient.Domain}/api/v2{contextUrl}";

            try
            {
                return fullUrl
                    .WithOAuthBearerToken(_apiClient.AccessToken)
                    .PostJsonAsync(postObject)
                    .ReceiveJson<TResult>();
            }
            catch (FlurlHttpException e)
            {
                _logger.Error(e, $"Could not call {contextUrl}");

                throw;
            }
        }
    }
}