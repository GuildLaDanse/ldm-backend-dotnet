using System.Threading.Tasks;
using Auth0.Abstractions.Models;

namespace Auth0.Abstractions.UserApi
{
    public interface ISearchUsersApi
    {
        Task<SearchUsers.User[]> SearchUsersAsync();

        Task<SearchUsersByEmail.User[]> SearchByEmailAsync(string email);
    }
}