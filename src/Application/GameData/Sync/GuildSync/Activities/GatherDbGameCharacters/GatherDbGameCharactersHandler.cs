using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LaDanse.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LaDanse.Application.GameData.Sync.GuildSync.Activities.GatherDbGameCharacters
{
    public class GatherDbGameCharactersHandler : IRequestHandler<GatherDbGameCharacters, SyncedDbGameCharacters>
    {
        private readonly ILaDanseDbContext _laDanseDbContext;
        
        public GatherDbGameCharactersHandler(ILaDanseDbContext laDanseDbContext)
        {
            _laDanseDbContext = laDanseDbContext;
        }
        
        public Task<SyncedDbGameCharacters> Handle(GatherDbGameCharacters request, CancellationToken cancellationToken)
        {
            // fetch guild with given guildSlug
            var gameGuildSync = _laDanseDbContext.GameGuildSyncs
                .Where(gs => gs.GameGuild.GameRealm.Name.Equals(request.RealmSlug, StringComparison.Ordinal))
                .Single(gs => gs.GameGuild.Name.Equals(request.GuildSlug, StringComparison.Ordinal));

            // fetch game character versions for given ids
            var gameCharacterVersions = _laDanseDbContext.GameCharacterVersions
                .Where(gcv => gcv.EndTime == null)
                .Where(gcv => gcv.GameCharacter.EndTime == null)
                .Where(gcv => _laDanseDbContext.TrackedBys
                    .Where(tb => tb.GameCharacterSourceId == gameGuildSync.Id)
                    .Where(tb => tb.EndTime == null)
                    .Select(tb => tb.GameCharacterId)
                    .Contains(gcv.GameCharacterId))
                .Include(gcv => gcv.GameCharacter)
                .Include(gcv => gcv.GameClass)
                .Include(gcv => gcv.GameRace)
                .Include(gcv => gcv.GameRace.GameFaction)
                .Include(gcv => gcv.GameCharacter.GameRealm)
                .ToList();

            return Task.FromResult(new SyncedDbGameCharacters
            {
                GameCharacterVersions = gameCharacterVersions,
                GameGuildSync = gameGuildSync
            });
        }
    }
}