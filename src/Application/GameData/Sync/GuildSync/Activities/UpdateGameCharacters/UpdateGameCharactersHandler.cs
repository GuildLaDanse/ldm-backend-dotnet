using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace LaDanse.Application.GameData.Sync.GuildSync.Activities.UpdateGameCharacters
{
    public class UpdateGameCharactersHandler : IRequestHandler<UpdateGameCharacters, Unit>
    {
        private readonly ILogger _logger = Log.ForContext<UpdateGameCharactersHandler>();

        public Task<Unit> Handle(UpdateGameCharacters request, CancellationToken cancellationToken)
        {
            foreach (var updateAction in request.GameCharactersToUpdate)
            {
                var rosterMember = updateAction.BattleNetGuildMember.Character;
                var dbGameCharacterVersion = updateAction.GameCharacterVersion;

                _logger.Information($"Updating {rosterMember.Name}");

                if (rosterMember.Level != dbGameCharacterVersion.Level)
                {
                    _logger.Information($"\tLevel changed");
                }

                if (rosterMember.PlayableRace.Id != dbGameCharacterVersion.GameRace.GameId)
                {
                    _logger.Information($"\tRace changed");
                }

                if (rosterMember.PlayableClass.Id != dbGameCharacterVersion.GameClass.GameId)
                {
                    _logger.Information($"\tClass changed");
                }
            }

            return Unit.Task;
        }
    }
}