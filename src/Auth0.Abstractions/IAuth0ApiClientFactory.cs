using System.Threading.Tasks;

namespace LaDanse.External.Auth0.Abstractions
{
    public interface IAuth0ApiClientFactory
    {
        Task<IAuth0ApiClient> CreateClientAsync(
            string domain,
            string audience,
            string clientId,
            string clientSecret);
    }
}