using System.Collections.Generic;
using LaDanse.Application.GameData.Sync.GuildSync.Activities.CalculateSyncActions;
using LaDanse.Domain.Entities.GameData.Sync.Guild;
using MediatR;

namespace LaDanse.Application.GameData.Sync.GuildSync.Activities.UpdateGameCharacters
{
    public class UpdateGameCharacters : IRequest<Unit>
    {
        public GameGuildSync GameGuildSync { get; set; }

        public IEnumerable<UpdateAction> GameCharactersToUpdate { get; set; }
    }
}