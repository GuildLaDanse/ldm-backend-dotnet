using System.Threading.Tasks;
using LaDanse.External.Auth0.Abstractions.Models;

namespace LaDanse.External.Auth0.Abstractions.UserApi
{
    public interface ISearchUsersApi
    {
        Task<SearchUsers.User[]> SearchUsersAsync();

        Task<SearchUsersByEmail.User[]> SearchByEmailAsync(string email);
    }
}