using LaDanse.External.Auth0.Abstractions.UserApi;

namespace LaDanse.External.Auth0.Abstractions
{
    public interface IAuth0ApiClient
    {
        ISearchUsersApi SearchUsersApi();

        IManageUsersApi ManageUsersApi();
    }
}