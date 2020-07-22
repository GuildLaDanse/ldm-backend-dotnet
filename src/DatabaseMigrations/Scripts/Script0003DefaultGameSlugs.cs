using System;
using System.Data;
using System.Text;
using DbUp.Engine;

namespace DatabaseMigrations.Scripts
{
    public class Script0003DefaultGameSlugs : IScript
    {
        public string ProvideScript(Func<IDbCommand> dbCommandFactory)
        {
            var scriptBuilder = new StringBuilder();
            
            UpdateGameGuildSlugs(dbCommandFactory, scriptBuilder);
            UpdateGameRealmSlugs(dbCommandFactory, scriptBuilder);

            return scriptBuilder.ToString();
        }

        private void UpdateGameGuildSlugs(Func<IDbCommand> dbCommandFactory, StringBuilder scriptBuilder)
        {
            var dbCommand = dbCommandFactory.Invoke();

            dbCommand.CommandText = "SELECT id, name FROM GameGuild";
            
            using var reader = dbCommand.ExecuteReader();
            while (reader.Read())
            {
                var gameGuildId = reader.GetString(0);
                var fullName = reader.GetString(1);

                var gameSlug = CreateGameSlug(fullName);

                scriptBuilder.AppendLine($"UPDATE GameGuild SET gameSlug=\"{gameSlug}\" WHERE id = \"{gameGuildId}\";");
            }
        }
        
        private void UpdateGameRealmSlugs(Func<IDbCommand> dbCommandFactory, StringBuilder scriptBuilder)
        {
            var dbCommand = dbCommandFactory.Invoke();

            dbCommand.CommandText = "SELECT id, name FROM GameRealm";
            
            using var reader = dbCommand.ExecuteReader();
            while (reader.Read())
            {
                var gameRealmId = reader.GetString(0);
                var fullName = reader.GetString(1);

                var gameSlug = CreateGameSlug(fullName);

                scriptBuilder.AppendLine($"UPDATE GameRealm SET gameSlug=\"{gameSlug}\" WHERE id = \"{gameRealmId}\";");
            }
        }

        private string CreateGameSlug(string originalName)
        {
            return originalName.ToLower().Replace(" ", "-");
        }
    }
}