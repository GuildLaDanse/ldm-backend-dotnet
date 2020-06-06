using System.Threading.Tasks;

namespace LaDanse.External.BattleNet.Abstractions
{
    public interface IBattleNetApiClientFactory
    {
        Task<IBattleNetApiClient> CreateClientAsync(
            ApiRegion apiRegion,
            string clientId, 
            string clientSecret);
    }
}
