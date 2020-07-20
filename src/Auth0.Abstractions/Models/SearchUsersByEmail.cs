using Newtonsoft.Json;

namespace Auth0.Abstractions.Models
{
    public class SearchUsersByEmail
    {
        public class User
        {
            [JsonProperty("email")] public string Email { get; set; }

            [JsonProperty("email_verified")] public bool EmailVerified { get; set; }

            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("nickname")] public string Nickname { get; set; }

            [JsonProperty("user_id")] public string UserId { get; set; }

            [JsonProperty("identities")] public Identity[] Identities { get; set; }
        }

        public class Identity
        {
            [JsonProperty("connection")] public string Connectoion { get; set; }

            [JsonProperty("provider")] public string Provider { get; set; }

            [JsonProperty("user_id")] public string UserId { get; set; }

            [JsonProperty("isSocial")] public bool IsSocial { get; set; }
        }
    }
}