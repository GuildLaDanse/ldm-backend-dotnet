using System.Threading.Tasks;
using LaDanse.External.Auth0.Abstractions.Models;

namespace LaDanse.External.Auth0.Abstractions.UserApi
{
    public interface IManageUsersApi
    {
        Task<CreateUser.Response> CreateUserAsync(CreateUser.Request request);

        void GetUserAysnc();

        void DeleteUserAsync(string userId);

        void UpdateUserAsync();
    }
}