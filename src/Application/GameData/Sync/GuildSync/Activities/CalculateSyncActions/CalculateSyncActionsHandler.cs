using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LaDanse.Domain.Entities.GameData.Characters;
using LaDanse.External.BattleNet.Abstractions.Models.GuildRoster;
using MediatR;
using Serilog;

namespace LaDanse.Application.GameData.Sync.GuildSync.Activities.CalculateSyncActions
{
    public class CalculateSyncActionsHandler : IRequestHandler<CalculateSyncActions, SyncActions>
    {
        private readonly ILogger _logger = Log.ForContext<CalculateSyncActionsHandler>();

        public Task<SyncActions> Handle(CalculateSyncActions request, CancellationToken cancellationToken)
        {
            var sortedBattleNetGuildRoster = request.BattleNetGuildRoster.Members
                .OrderBy(m => m.Character.Name, StringComparer.Ordinal);

            var sortedGameCharacterVersions = request.GameCharacterVersions
                .OrderBy(m => m.GameCharacter.Name, StringComparer.Ordinal);

            var addActions = new List<Member>();
            var updateActions = new List<UpdateAction>();
            var removeActions = new List<GameCharacterVersion>();

            _logger.Information(
                $"Db list has size {request.GameCharacterVersions.Count}");

            using (var rosterIterator = sortedBattleNetGuildRoster.GetEnumerator())
            using (var dbIterator = sortedGameCharacterVersions.GetEnumerator())
            {
                var rosterHasNext = rosterIterator.MoveNext();
                var dbHasNext = dbIterator.MoveNext();

                _logger.Information(
                    $"Iterators are {rosterHasNext} and {dbHasNext}");

                while (rosterHasNext && dbHasNext)
                {
                    var currentRosterMember = rosterIterator.Current;
                    var currentDbCharacter = dbIterator.Current;

                    Debug.Assert(currentRosterMember != null, nameof(currentRosterMember) + " != null");
                    var rosterMemberName = currentRosterMember.Character.Name;
                    Debug.Assert(currentDbCharacter != null, nameof(currentDbCharacter) + " != null");
                    var dbCharacterName = currentDbCharacter.GameCharacter.Name;

                    _logger.Debug($"Comparing {rosterMemberName} with {dbCharacterName}");

                    var nameComparison = string.Compare(rosterMemberName, dbCharacterName, StringComparison.Ordinal);

                    if (nameComparison == 0)
                    {
                        _logger.Debug(
                            $"Member to update - {rosterMemberName} / {dbCharacterName} / {currentDbCharacter.GameCharacter.Id}");
                        // both names are equal, add to update actions

                        updateActions.Add(new UpdateAction
                        {
                            BattleNetGuildMember = currentRosterMember,
                            GameCharacterVersion = currentDbCharacter
                        });

                        // advance both iterators

                        rosterHasNext = rosterIterator.MoveNext();
                        dbHasNext = dbIterator.MoveNext();
                    }
                    else if (nameComparison < 0)
                    {
                        _logger.Debug($"Member to add - {rosterMemberName}");

                        // roster name comes before db name, meaning the name is not in the db, add it

                        addActions.Add(currentRosterMember);

                        // advance roster iterator

                        rosterHasNext = rosterIterator.MoveNext();
                    }
                    else
                    {
                        _logger.Debug($"Member to remove - {dbCharacterName}");

                        // roster name comes after db name, meaning db has a name that is not in the roster, remove it

                        removeActions.Add(currentDbCharacter);

                        // advance roster iterator

                        dbHasNext = dbIterator.MoveNext();
                    }
                }

                while (rosterHasNext)
                {
                    addActions.Add(rosterIterator.Current);

                    rosterHasNext = rosterIterator.MoveNext();
                }

                while (dbHasNext)
                {
                    removeActions.Add(dbIterator.Current);

                    dbHasNext = dbIterator.MoveNext();
                }
            }

            return Task.FromResult(new SyncActions
            {
                GameCharactersToAdd = addActions,
                GameCharactersToUpdate = updateActions,
                GameCharactersToRemove = removeActions
            });
        }
    }
}