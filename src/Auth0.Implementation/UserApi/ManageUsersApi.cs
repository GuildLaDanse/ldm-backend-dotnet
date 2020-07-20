using System;
using System.Threading.Tasks;
using Auth0.Abstractions.Models;
using Auth0.Abstractions.UserApi;
using Serilog;

namespace Auth0.Implementation.UserApi
{
    public class ManageUsersApi : Auth0Api, IManageUsersApi
    {
        private readonly ILogger _logger = Log.ForContext<ManageUsersApi>();

        public ManageUsersApi(Auth0ApiClient apiClient)
            : base(apiClient)
        {
        }

        public Task<CreateUser.Response> CreateUserAsync(CreateUser.Request request)
        {
            return CallPostApiAsync<CreateUser.Request, CreateUser.Response>("/users", request);
        }

        public void GetUserAysnc()
        {
            throw new NotImplementedException();
        }

        public void DeleteUserAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateUserAsync()
        {
            throw new NotImplementedException();
        }
    }
}