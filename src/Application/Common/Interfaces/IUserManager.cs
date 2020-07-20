using System.Threading.Tasks;
using LaDanse.Application.Common.Models;

namespace LaDanse.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}