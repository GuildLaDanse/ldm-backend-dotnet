using Microsoft.Extensions.Configuration;

namespace LaDanse.Common.Configuration
{
    public static class EnvironmentVariablesExtensions
    {
        public static bool CheckEnvironmentVariablePresence(
            this IConfiguration configuration,
            string envName)
        {
            var envValue = configuration.GetEnvironmentValue(envName);

            return !string.IsNullOrEmpty(envValue);
        }

        public static string GetEnvironmentValue(
            this IConfiguration configuration,
            string envName)
        {
            return configuration.GetSection(envName).Value;
        }
    }
}