using LaDanse.Configuration.Abstractions;
using LaDanse.Infrastructure.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace LaDanse.Configuration.Implementation
{
    public class LaDanseConfiguration : ILaDanseConfiguration, IBattleNetConfiguration, IAuth0AdminConfiguration
    {
        private readonly ILogger _logger = Log.ForContext<LaDanseConfiguration>();

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public LaDanseConfiguration(
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;

            InitializeConfiguration();
        }

        public string BaseUrl()
        {
            return _configuration.GetEnvironmentValue(EnvNames.LaDanseBaseUrl);
        }

        public IAuth0AdminConfiguration Auth0AdminConfiguration()
        {
            return this;
        }

        public IBattleNetConfiguration BattleNetConfiguration()
        {
            return this;
        }

        #region IBattleNetConfiguration

        public string BattleNetClientId()
        {
            return _configuration.GetEnvironmentValue(EnvNames.BattleNetClientId);
        }

        public string BattleNetClientSecret()
        {
            return _configuration.GetEnvironmentValue(EnvNames.BattleNetClientSecret);
        }

        #endregion
        
        #region IAuth0AdminConfiguration
        
        public string Domain()
        {
            return _configuration.GetEnvironmentValue(EnvNames.Auth0Domain);
        }
        
        public string Audience()
        {
            return _configuration.GetEnvironmentValue(EnvNames.Auth0AdminAudience);
        }
        
        public string ClientId()
        {
            return _configuration.GetEnvironmentValue(EnvNames.Auth0ClientId);
        }
        
        public string ClientSecret()
        {
            return _configuration.GetEnvironmentValue(EnvNames.Auth0ClientSecret);
        }
        
        public string DefaultDatabaseConnection()
        {
            return _configuration.GetEnvironmentValue(EnvNames.Auth0AdminDefaultConnection);
        }
        
        #endregion
        
        #region IAuth0AdminConfiguration

        private void InitializeConfiguration()
        {
            // check existence of database connection configuration
            CheckEnvironmentVariable(EnvNames.LaDanseDatabaseConnection);
            
            // check existence of various configuration values
            CheckEnvironmentVariable(EnvNames.LaDanseBaseUrl);

            // check existence of Battle Net configuration
            CheckEnvironmentVariable(EnvNames.BattleNetClientId);
            CheckEnvironmentVariable(EnvNames.BattleNetClientSecret);

            // check existence of Auth0 configuration
            CheckEnvironmentVariable(EnvNames.Auth0Domain);
            CheckEnvironmentVariable(EnvNames.Auth0ClientId);
            CheckEnvironmentVariable(EnvNames.Auth0ClientSecret);
            CheckEnvironmentVariable(EnvNames.Auth0AdminAudience);
            CheckEnvironmentVariable(EnvNames.Auth0AdminClientId);
            CheckEnvironmentVariable(EnvNames.Auth0AdminClientSecret);
            CheckEnvironmentVariable(EnvNames.Auth0AdminDefaultConnection);
        }

        private void CheckEnvironmentVariable(string envName)
        {
            var envValue = _configuration.GetEnvironmentValue(envName);

            if (string.IsNullOrEmpty(envValue))
            {
                _logger.Warning($"No value given for '{envName}'. Did you forgot to set the environment value?");
            }
            else
            {
                _logger.Information(_environment.IsDevelopment()
                    ? $"Found a value for '{envName}': '{envValue}'"
                    : $"Found a value for '{envName}'");
            }
        }
        
        #endregion
    }
}