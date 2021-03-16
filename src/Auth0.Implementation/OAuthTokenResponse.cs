using Newtonsoft.Json;

namespace LaDanse.External.Auth0.Implementation
{
    public class OAuthTokenResponse
    {
        [JsonProperty("access_token")] public string AccessToken { get; set; }

        [JsonProperty("token_type")] public string TokenType { get; set; }

        [JsonProperty("scope")] public string Scope { get; set; }

        [JsonProperty("expires_in")] public int ExpiresIn { get; set; }
    }
}