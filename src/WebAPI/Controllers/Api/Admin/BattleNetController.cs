using System.Threading.Tasks;
using LaDanse.Application.GameData.Sync.GuildSync;
using LaDanse.Application.GameData.Sync.GuildSync.Activities.CalculateSyncActions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Api.Admin
{
    [ApiController]
    public class BattleNetController : ControllerBase
    {
        [HttpGet("/api/admin/battlenet/sync-guilds")]
        [Authorize(Roles = "admin")]
        public async Task<SyncActions> SyncGuilds([FromServices] GuildSyncWorkflow guildSyncWorkflow)
        {
            return await guildSyncWorkflow.TemporaryMethod();
        }
    }
}