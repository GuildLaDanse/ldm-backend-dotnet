using Auth0.Abstractions;
using Auth0.Abstractions.UserApi;
using Auth0.Implementation.SearchApi;
using Auth0.Implementation.UserApi;
using Serilog;

namespace Auth0.Implementation
{
    public class Auth0ApiClient : IAuth0ApiClient
    {
        private readonly ILogger _logger = Log.ForContext<Auth0ApiClient>();

        public string Domain { get; }

        public string AccessToken { get; }

        public int ExpiresIn { get; }

        public Auth0ApiClient(string domain, string accessToken, int expiresIn)
        {
            Domain = domain;
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
        }

        public ISearchUsersApi SearchUsersApi()
        {
            return new SearchUsersApi(this);
        }

        public IManageUsersApi ManagerUsersApi()
        {
            return new ManageUsersApi(this);
        }
    }
}