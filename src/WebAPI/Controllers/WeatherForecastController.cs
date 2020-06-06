using System.Threading.Tasks;
using LaDanse.Common.Configuration;
using LaDanse.External.BattleNet.Abstractions;
using LaDanse.External.BattleNet.Abstractions.Models.GuildRoster;
using LaDanse.External.BattleNet.Abstractions.ProfileApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILaDanseConfiguration _laDanseConfiguration;
        private readonly IBattleNetApiClientFactory _battleNetApiClientFactory;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            ILaDanseConfiguration laDanseConfiguration,
            IBattleNetApiClientFactory battleNetApiClientFactory)
        {
            _logger = logger;
            _laDanseConfiguration = laDanseConfiguration;
            _battleNetApiClientFactory = battleNetApiClientFactory;
        }

        [HttpGet]
        public async Task<GuildRoster> GetAsync()
        {
            var apiClient = await _battleNetApiClientFactory.CreateClientAsync(
                ApiRegion.Eu,
                _laDanseConfiguration.BattleNetClientId(),
                _laDanseConfiguration.BattleNetClientSecret());

            var guildApi = apiClient.GuildApi();
            
            return await guildApi.GuildRosterAsync("defias-brotherhood", "la-danse-macabre");
        }
    }
}
