using System.Collections.Generic;
using LaDanse.Domain.Entities.GameData.Characters;
using MediatR;

namespace LaDanse.Application.GameData.Sync.GuildSync.Activities.GatherDbGameCharacters
{
    public class GatherDbGameCharacters : IRequest<SyncedDbGameCharacters>
    {
        public string RealmSlug { get; set; }
        public string GuildSlug { get; set; }
    }
}