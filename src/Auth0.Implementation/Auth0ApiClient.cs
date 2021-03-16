using LaDanse.External.Auth0.Abstractions;
using LaDanse.External.Auth0.Abstractions.UserApi;
using LaDanse.External.Auth0.Implementation.SearchApi;
using LaDanse.External.Auth0.Implementation.UserApi;
using Serilog;

namespace LaDanse.External.Auth0.Implementation
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

        public IManageUsersApi ManageUsersApi()
        {
            return new ManageUsersApi(this);
        }
    }
}