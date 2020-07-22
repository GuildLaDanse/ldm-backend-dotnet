using Auth0.Abstractions.UserApi;

namespace Auth0.Abstractions
{
    public interface IAuth0ApiClient
    {
        ISearchUsersApi SearchUsersApi();

        IManageUsersApi ManageUsersApi();
    }
}