using System.Threading.Tasks;
using LaDanse.Application.GameData.Sync.GuildSync.Activities.CalculateSyncActions;
using LaDanse.Application.GameData.Sync.GuildSync.Activities.GatherBattleNetGuildRoster;
using LaDanse.Application.GameData.Sync.GuildSync.Activities.GatherDbGameCharacters;
using LaDanse.Application.GameData.Sync.GuildSync.Activities.UpdateGameCharacters;
using MediatR;

namespace LaDanse.Application.GameData.Sync.GuildSync
{
    public class GuildSyncWorkflow
    {
        private readonly IMediator _mediator;
        
        public GuildSyncWorkflow(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<SyncActions> TemporaryMethod()
        {
            // fetch roster from BattleNet
            var guildRoster = await _mediator.Send(new GatherBattleNetGuildRoster
            {
                GuildSlug = "la-danse-macabre",
                RealmSlug = "defias-brotherhood"
            });
            
            // fetch characters from database
            var syncedDbGameCharacters = await _mediator.Send(new GatherDbGameCharacters
            {
                RealmSlug = "Defias Brotherhood",
                GuildSlug = "La Danse Macabre"
            });

            var syncActions = await _mediator.Send(new CalculateSyncActions
            {
                BattleNetGuildRoster = guildRoster,
                GameCharacterVersions = syncedDbGameCharacters.GameCharacterVersions
            });

            await _mediator.Send(new UpdateGameCharacters
            {
                GameGuildSync = syncedDbGameCharacters.GameGuildSync,
                GameCharactersToUpdate = syncActions.GameCharactersToUpdate
            });

            return syncActions;
        }
    }
}