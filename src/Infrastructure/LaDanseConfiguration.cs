using LaDanse.Common.Configuration;
using Microsoft.Extensions.Configuration;

namespace LaDanse.Infrastructure
{
    public class LaDanseConfiguration : ILaDanseConfiguration
    {
        private readonly IConfiguration _configuration;

        public LaDanseConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string BattleNetClientId()
        {
            return _configuration.GetEnvironmentValue(EnvNames.BattleNetClientId);
        }

        public string BattleNetClientSecret()
        {
            return _configuration.GetEnvironmentValue(EnvNames.BattleNetClientSecret);
        }
    }
}