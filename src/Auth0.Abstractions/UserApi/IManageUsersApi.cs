using System.Threading.Tasks;
using Auth0.Abstractions.Models;

namespace Auth0.Abstractions.UserApi
{
    public interface IManageUsersApi
    {
        Task<CreateUser.Response> CreateUserAsync(CreateUser.Request request);

        void GetUserAysnc();

        void DeleteUserAsync();

        void UpdateUserAsync();
    }
}