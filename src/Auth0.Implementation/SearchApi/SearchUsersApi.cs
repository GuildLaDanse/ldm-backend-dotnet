using System;
using System.Threading.Tasks;
using LaDanse.External.Auth0.Abstractions.Models;
using LaDanse.External.Auth0.Abstractions.UserApi;
using Serilog;

namespace LaDanse.External.Auth0.Implementation.SearchApi
{
    public class SearchUsersApi : Auth0Api, ISearchUsersApi
    {
        private readonly ILogger _logger = Log.ForContext<SearchUsersApi>();

        public SearchUsersApi(Auth0ApiClient apiClient)
            : base(apiClient)
        {
        }

        public Task<SearchUsers.User[]> SearchUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SearchUsersByEmail.User[]> SearchByEmailAsync(string email)
        {
            return CallGetApiAsync<SearchUsersByEmail.User[]>(
                "/users-by-email",
                new
                {
                    email = email
                });
        }
    }
}