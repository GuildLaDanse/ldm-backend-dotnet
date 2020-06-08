using System.Threading.Tasks;
using LaDanse.Application.GameData.Sync.GuildSync;
using LaDanse.Application.GameData.Sync.GuildSync.Activities.CalculateSyncActions;
using LaDanse.Common.Configuration;
using LaDanse.External.BattleNet.Abstractions;
using LaDanse.External.BattleNet.Abstractions.Models.GuildRoster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly ILaDanseConfiguration _laDanseConfiguration;
        private readonly IBattleNetApiClientFactory _battleNetApiClientFactory;

        public TestController(
            ILogger<TestController> logger,
            ILaDanseConfiguration laDanseConfiguration,
            IBattleNetApiClientFactory battleNetApiClientFactory)
        {
            _logger = logger;
            _laDanseConfiguration = laDanseConfiguration;
            _battleNetApiClientFactory = battleNetApiClientFactory;
        }

        [HttpGet("/Test/GuildRoster")]
        public async Task<Roster> GetGuildRosterAsync()
        {
            var apiClient = await _battleNetApiClientFactory.CreateClientAsync(
                ApiRegion.Eu,
                _laDanseConfiguration.BattleNetClientId(),
                _laDanseConfiguration.BattleNetClientSecret());

            var guildApi = apiClient.GuildApi();
            
            return await guildApi.GuildRosterAsync("defias-brotherhood", "la-danse-macabre");
        }
        
        [HttpGet("/Test/SyncGuild")]
        public async Task<SyncActions> GetAsync([FromServices] GuildSyncWorkflow guildSyncWorkflow)
        {
            return await guildSyncWorkflow.TemporaryMethod();
        }
    }
}
